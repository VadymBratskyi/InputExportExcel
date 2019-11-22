using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelParserLibrary.Inrterface;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using System;
using System.IO;
using System.Linq;

namespace ExcelParserLibrary.Process
{
    public class DomProcessParsing : ProcesParsing, IProcesParsing
    {
        public DomProcessParsing(InputExportDbContext context) : base(context) { }

        public bool ParsingIntoDb(string filePath)
        {

            try
            {
                using (Stream swtream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
                    {

                        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                        foreach (Row row in sheetData.Elements<Row>().Skip(1))
                        {
                            var testContact = new TestContact();

                            foreach (Cell cell in row.Elements<Cell>())
                            {

                                FullingProperties(testContact, cell, workbookPart);

                            }

                            listContacts.Add(testContact);
                        }

                        SaveItemsDataToDb();

                        return true;

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
