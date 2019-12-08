using ExcelParserLibrary.Inrterface;
using InputExportExcel.DAL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ExcelParserLibrary.Process
{
	public class FromDbProcessParsing : ProcesParsing, IProcesParsing
	{
		public FromDbProcessParsing(InputExportDbContext context) : base(context) { }

		public bool ParsingIntoDb(string filePath)
		{			
		
			return true;
		}
	}
	
}
