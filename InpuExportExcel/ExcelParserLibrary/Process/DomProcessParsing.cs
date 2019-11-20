using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelParserLibrary.Inrterface;
using ExcelParserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelParserLibrary.Process
{
    public class DomProcessParsing: IProcesParsing
    {
        public DomProcessParsing()
        {

        }

        public List<TestObject> Parsing(string filePath)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                List<TestObject> listObjects = new List<TestObject>();

                foreach (Row r in sheetData.Elements<Row>().Skip(1))
                {
                    var testObject = new TestObject();

                    foreach (Cell c in r.Elements<Cell>())
                    {
                        var currentValue = string.Empty;
                        if (c.DataType != null) {

                            if (c.DataType == CellValues.SharedString) {

                                int id;
                                if (Int32.TryParse(c.InnerText, out id))
                                {
                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);

                                    if (item.Text != null)
                                    {
                                        if (Regex.IsMatch(c.CellReference, "A\\d"))
                                        {
                                            testObject.Name = item.Text.Text;
                                        }
                                        else if (Regex.IsMatch(c.CellReference, "B\\d"))
                                        {
                                            testObject.Number = item.Text.Text == "М" ? 1 : 0;
                                        }                                        
                                    }  
                                }
                            }
                        }             
                    }
                    listObjects.Add(testObject);
                }
                return listObjects;
            }            
            
        }
    }
}
