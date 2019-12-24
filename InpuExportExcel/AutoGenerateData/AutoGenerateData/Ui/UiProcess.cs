﻿using AutoGenerateData.Generator.Base;
using AutoGenerateData.Generator.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutoGenerateData.Ui
{
	public static class UiProcess
	{
		private static int CountImported = 0;

		private static Dictionary<int, string> entityDictionary = new Dictionary<int, string>() {
			{ 1, "Contact" },
			{ 2, "Account" }
		};

		public static void CleareImportedCount() {
			CountImported = 0;
		}

		public static bool GoOn() {

			Console.Write("Do you want to go on? (y/n): ");
			var goON = Console.ReadLine();
			if (goON != "y")
			{
				Console.WriteLine("\n\rThe End!");
				return false;
			}

			return true;
		}

		public static void ProgressImport(int countItems)
		{
			CountImported += countItems;
			Console.WriteLine($"Count imported items: {CountImported}");
		}

		public static int SetCountItems()
		{

			Console.Write("Count items for import: ");

			int count = 0;
			if (!Int32.TryParse(Console.ReadLine(), out count))
			{
				var error = "Not correct your value";
				GetErrorMessage(error);
			};

			return count;
		}

		public static Creator SelectCreator()
		{		
			Console.WriteLine("We can Auto Generate these objects: ");
			
			foreach (var item in entityDictionary) {
				Console.WriteLine($"{item.Key}: {item.Value}");
			}

			Console.Write("Select one of the case: ");

			int index = 0;
			if (!Int32.TryParse(Console.ReadLine(), out index))
			{
				var error = "Not correct your index";
				GetErrorMessage(error);
			};
			
			return GetEntity(index);
		}
		
		public static void GetResultMessage(Stopwatch sw)
		{
			TimeSpan ts = sw.Elapsed;

			string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds,
					ts.Milliseconds / 10);

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("SpendTime " + elapsedTime);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{CountImported} items imported successfully!!!");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void GetErrorMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ERROR!! " + message);
			Console.ForegroundColor = ConsoleColor.White;
		}

		private static Creator GetEntity(int index) => index switch {
			1 => new GeneratorContact(),
			2 => new GeneratorAccount(),
			_ => throw new KeyNotFoundException()
		};

	}
}
