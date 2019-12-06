﻿using AutoGenerateData.Generator;
using AutoGenerateData.Generator.Items;
using AutoGenerateData.Models.Db;
using System;
using System.Diagnostics;

namespace AutoGenerateData
{
	class Program
	{
		private static int CountImported = 0;

		static void Main(string[] args)
		{

			try
			{
				using (var context = new GenerateDbContext())
				{

					Console.WriteLine("Auto Generator");
					Console.Write("Count items for import: ");

					int count = 0;
					if (!Int32.TryParse(Console.ReadLine(), out count))
					{
						count = 10;
					};

					GenerateItems generateItems = new GenerateItems(count, context);
					generateItems.Notify += ProgressImport;

					Stopwatch stopwatch = new Stopwatch();

					stopwatch.Start();

					generateItems.RunGenerator(new GeneratorAccount());

					stopwatch.Stop();

					GetResultMessage(stopwatch);

				}
			}
			catch (Exception ex) {

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ForegroundColor = ConsoleColor.White;
			}

		}

		private static void ProgressImport(int countItems) {
			CountImported += countItems;
			Console.WriteLine($"Count imported items: {CountImported}");
		}

		private static void GetResultMessage(Stopwatch sw) {

			TimeSpan ts = sw.Elapsed;

			string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
					ts.Hours, ts.Minutes, ts.Seconds,
					ts.Milliseconds / 10);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("SpendTime " + elapsedTime);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{CountImported} items imported successfully!!!");
			Console.ForegroundColor = ConsoleColor.White;
			Console.ReadKey();
		}
	}
}
