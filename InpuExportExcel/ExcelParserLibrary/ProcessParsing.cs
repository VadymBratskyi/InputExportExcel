using DocumentFormat.OpenXml.Packaging;
using System;

namespace ExcelParserLibrary
{
    public class ProcessParsing
    {
        public static void ReadExcelFile(string filePath) {

            try {

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                {

                }

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
