using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelParserLibrary.Inrterface;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelParserLibrary.Process
{
    public class DomProcessParsing: ProcesParsing, IProcesParsing
    {
        public DomProcessParsing(InputExportDbContext context) : base(context) { }

        public bool ParsingIntoDb(string filePath)
        {            

            try
            {
                using (Stream swtream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false)) {

                        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                        foreach (Row row in sheetData.Elements<Row>().Skip(1))
                        {
                            var testObject = new TestObject();

                            foreach (Cell cell in row.Elements<Cell>())
                            {

                                var cellIndex = GetColumnIndexFromName(GetColumnName(cell.CellReference));

                                if (cellIndex == 1)
                                {
                                    testObject.Name = GetCellValue(cell, workbookPart);
                                }
                                else if (cellIndex == 2)
                                {
                                    testObject.Gender = GetCellValue(cell, workbookPart);
                                }

                            }

                            listObjects.Add(testObject);
                        }

                        SaveItemsDataToDb();

                        return true;

                    }
                
                }

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }                       
            
        }

    }

}
