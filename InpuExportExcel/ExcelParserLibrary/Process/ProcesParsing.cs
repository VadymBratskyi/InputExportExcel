using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelParserLibrary.Process
{
    public class ProcesParsing
    {
        public List<TestObject> listObjects;

        InputExportDbContext _db;

        public ProcesParsing(InputExportDbContext context) {
            _db = context;
            listObjects = new List<TestObject>();
        }

        protected string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            string cellValue = string.Empty;

            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                SharedStringItem item =  workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(cell.CellValue.InnerText));
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
            for (int lastCharPos = 0; lastCharPos <= cellReference.Length; lastCharPos++) {

                if (char.IsNumber(cellReference[lastCharPos])) {

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

        protected void SaveItemsDataToDb() {

            if (listObjects.Any()) {
                _db.AddRange(listObjects);
                _db.SaveChanges();
                listObjects.Clear();
            }
        }

        protected void SaveSinglDataToDb(TestObject testObjetc) {

            if (testObjetc != null)
            {
                _db.AddRange(testObjetc);
                _db.SaveChanges();
            }
        }
    }
}
