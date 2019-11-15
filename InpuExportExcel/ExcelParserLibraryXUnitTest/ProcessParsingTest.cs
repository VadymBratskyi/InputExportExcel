using ExcelParserLibrary;
using System;
using Xunit;

namespace ExcelParserLibraryXUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var filePath = @"C:\GithubProject\InputExportExcel\InpuExportExcel\InpuExportExcel\wwwroot\Files\TestImport_1000.xlsx";

            var result = false;

            ProcessParsing.ReadExcelFile(filePath);

        }
    }
}
