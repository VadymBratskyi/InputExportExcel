using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelParserLibrary.Process
{
    public class ProcesParsing
    {

        public List<TestContact> listContacts;

        InputExportDbContext _db;

        public ProcesParsing(InputExportDbContext context)
        {
            _db = context;
            listContacts = new List<TestContact>();
        }

        protected string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            string cellValue = string.Empty;

            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(cell.CellValue.InnerText));
                if (item.Text != null)
                {
                    cellValue = item.Text.Text;
                }
            }
            else
            {
                if (cell.CellValue != null)
                {
                    cellValue = cell.CellValue.InnerText;
                }
            }
            return cellValue;
        }

        protected string GetColumnName(string cellReference)
        {
            for (int lastCharPos = 0; lastCharPos <= cellReference.Length; lastCharPos++)
            {

                if (char.IsNumber(cellReference[lastCharPos]))
                {

                    return cellReference.Substring(0, lastCharPos);

                }

            }

            throw new ArgumentOutOfRangeException("cellReference");
        }

        protected int GetColumnIndexFromName(string columnNameOrCellReference)
        {
            int columnIndex = 0;
            int factor = 1;

            for (int pos = columnNameOrCellReference.Length - 1; pos >= 0; pos--)
            {
                if (char.IsLetter(columnNameOrCellReference[pos]))
                {
                    columnIndex += factor * ((columnNameOrCellReference[pos] - 'A') + 1);
                    factor *= 26;
                }
            }

            return columnIndex;
        }

        protected void SaveItemsDataToDb()
        {

            if (listContacts.Any())
            {
                _db.AddRange(listContacts);
                _db.SaveChanges();
                listContacts.Clear();
            }
        }

        protected void SaveSinglDataToDb(TestContact testContact)
        {

            if (testContact != null)
            {
                _db.AddRange(testContact);
                _db.SaveChanges();
            }
        }

        protected void FullingProperties(TestContact testContact, Cell cell, WorkbookPart workbookPart)
        {

            var cellIndex = GetColumnIndexFromName(GetColumnName(cell.CellReference));

            switch (cellIndex)
            {

                case 1:
                    testContact.FullName = GetCellValue(cell, workbookPart);
                    break;
                case 2:
                    testContact.BirthDate = GetCellValue(cell, workbookPart);
                    break;
                case 3:
                    testContact.Account = GetCellValue(cell, workbookPart);
                    break;
                case 4:
                    testContact.BusinessPhone = GetCellValue(cell, workbookPart);
                    break;
                case 5:
                    testContact.Address = GetCellValue(cell, workbookPart);
                    break;
                case 6:
                    testContact.Email = GetCellValue(cell, workbookPart);
                    break;
                case 7:
                    testContact.Gender = GetCellValue(cell, workbookPart);
                    break;
                case 8:
                    testContact.JobTitle = GetCellValue(cell, workbookPart);
                    break;
                case 9:
                    testContact.Department = GetCellValue(cell, workbookPart);
                    break;
            }

        }
    }
}
