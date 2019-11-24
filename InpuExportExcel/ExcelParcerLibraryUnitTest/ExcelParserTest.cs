using ExcelParserLibrary.Process;
using InputExportExcel.DAL;
using NUnit.Framework;

namespace Tests
{
    public class ExcelParserTest
    {
        public ExcelParserTest() {

        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DomProcessParsingTest()
        {

            //var filePath = @"C:\VadimBratskyi\Git\VadymBratskyi\InputExportExcel\InpuExportExcel\InpuExportExcel\wwwroot\Files\TestValue_20000.xlsx";

            //var actual = 20000;

            //DomProcessParsing domProcess = new DomProcessParsing();
            //var expected = domProcess.ParsingIntoDb(filePath).Count;

            //Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SaxProcessParsingTest()
        {
            //var filePath = @"C:\VadimBratskyi\Git\VadymBratskyi\InputExportExcel\InpuExportExcel\InpuExportExcel\wwwroot\Files\TestValue_20000.xlsx";

            //var actual = 20000;

            //SaxProcessParsing domProcess = new SaxProcessParsing();
            //var expected = domProcess.ParsingIntoDb(filePath).Count;

            //Assert.AreEqual(expected, actual);
        }
    }
}