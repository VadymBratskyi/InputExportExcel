using ExcelParserLibrary;
using ExcelParserLibrary.Process;
using System;
using Xunit;

namespace ExcelParserLibraryXUnitTest
{
    public class ProcessParsingTest
    {
        [Fact]
        public void Test1()
        {
            var filePath = @"C:\VadimBratskyi\Git\VadymBratskyi\InputExportExcel\InpuExportExcel\InpuExportExcel\wwwroot\Files\TestImport_1000.xlsx";

            var result = false;

            DomProcessParsing domProcess = new DomProcessParsing();
            domProcess.Parsing(filePath);

            Assert.True(result);

        }
    }
}
