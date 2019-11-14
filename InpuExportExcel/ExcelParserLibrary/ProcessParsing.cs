using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Linq;
using System.Text;

namespace ExcelParserLibrary
{
    public class ProcessParsing
    {
        public static void ReadExcelFile(string filePath) {

            try {

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                {

                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets sheetsCollections = workbookPart.Workbook.GetFirstChild<Sheets>();
                    StringBuilder excelResult = new StringBuilder();

                    foreach (Sheet sheet in sheetsCollections) {

                        excelResult.AppendLine("Excel Sheet Name : " + sheet.Name);
                        excelResult.AppendLine("----------------------------------------------- ");

                        Worksheet worksheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;

                        SheetData sheetdata = (SheetData)worksheet.GetFirstChild<SheetData>();
                        foreach (Row currentRow in sheetdata) {

                            foreach (Cell currentCell in currentRow) {

                                var currentValue = string.Empty;
                                if (currentCell.DataType != null)
                                {

                                    if (currentCell.DataType == CellValues.SharedString)
                                    {

                                        int id;
                                        if (Int32.TryParse(currentCell.InnerText, out id))
                                        {
                                            SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);

                                            if (item.Text != null)
                                            {

                                                excelResult.Append(item.Text.Text + " ");

                                            }
                                            else if (item.InnerText != null)
                                            {

                                                currentValue = item.InnerText;

                                            }
                                            else if (item.InnerXml != null)
                                            {

                                                currentValue = item.InnerXml;

                                            }

                                        }

                                    }

                                } else {

                                    excelResult.Append(Convert.ToInt16(currentCell.InnerText) + " ");

                                }
                                
                            }

                            excelResult.AppendLine();

                        }

                        excelResult.Append("");

                    }

                }

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
