using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelParserLibrary.Inrterface;
using ExcelParserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelParserLibrary.Process
{
    public class SaxProcessParsing : IProcesParsing
    {
        public List<TestObject> Parsing(string filePath)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                string text;
                while (reader.Read())
                {
                    if (reader.ElementType == typeof(CellValue))
                    {
                        text = reader.GetText();
                        Console.Write(text + " ");
                    }
                }

                return new List<TestObject>();
            }
        }
    }
}
