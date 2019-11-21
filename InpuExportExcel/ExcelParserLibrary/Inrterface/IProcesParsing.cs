using InputExportExcel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParserLibrary.Inrterface
{
    public interface IProcesParsing
    {
        bool ParsingIntoDb(string filePath);
    }
}
