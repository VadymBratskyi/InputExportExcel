using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelParserLibrary.Inrterface;
using InputExportExcel.DAL;
using InputExportExcel.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExcelParserLibrary.Process
{
    public class SaxProcessParsing : ProcesParsing, IProcesParsing
    {

        public int CountInChunk { get; set; } = 200;

        public SaxProcessParsing(InputExportDbContext context) : base(context) { }

        public bool ParsingIntoDb(string filePath)
        {

            try
            {

                using (Stream swtream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {


                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false)) {

                        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                        OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);

                        int i = 0;

                        while (reader.Read()) {

                            if (reader.ElementType == typeof(Row))
                            {
                                if (i < 2)
                                {
                                    i++;
                                    continue;
                                }

                                reader.ReadFirstChild();

                                var testObject = new TestObject();

                                do
                                {                                    

                                    if (reader.ElementType == typeof(Cell))
                                    {
                                        Cell cell = (Cell)reader.LoadCurrentElement();

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

                                } while (reader.ReadNextSibling());

                                //SaveSinglDataToDb(testObject);

                                if (listObjects.Count < CountInChunk)
                                { 
                                    listObjects.Add(testObject);
                                }
                                else
                                {
                                    var first = listObjects.FirstOrDefault();
                                    var last = listObjects.LastOrDefault();

                                    SaveItemsDataToDb();
                                    listObjects.Add(testObject);
                                }

                            }

                        }

                        if (listObjects.Any()) {
                            SaveItemsDataToDb();
                        }

                    }    
                    
                }

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return true;
            
        }

        

    }   

}
