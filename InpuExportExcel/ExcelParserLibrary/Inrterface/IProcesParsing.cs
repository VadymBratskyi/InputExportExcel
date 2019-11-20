using ExcelParserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelParserLibrary.Inrterface
{
    public interface IProcesParsing
    {
        List<TestObject> Parsing(string filePath);
    }
}
