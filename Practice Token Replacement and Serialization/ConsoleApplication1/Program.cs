/*
 * Crayton McIntosh
 * Created - 11/4/2016
 * Last Modified - 11/4/2016
 * Practice token replacement
 * serialization and deserialization
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
	class Program
	{
		[Serializable]
		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Email { get; set; }
		}

		static void Main(string[] args)
		{
			Dictionary<string, object> collection = new Dictionary<string, object>
			{
				{"First" , new Person { FirstName = "Crayton", LastName = "Tosh", Email = "craytosh@gmail.com" }},
				{"Second", new Person {FirstName = "Dak", LastName = "Prescott", Email = "bigDak@gmail.com"}},
				{"Ezekiel", new Person {FirstName = "Ezekiel", LastName = "Elliot", Email = "Zelliot@gmail.com"}}
			};

			//console output
			string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
			Console.WriteLine(json);
			Console.ReadLine();
			
			//file output
			File.AppendAllText(@"C:\Users\cmcintosh\Documents\Visual Studio 2013\Projects\ConsoleApplication1\names.json", json);

			var fileValue = File.ReadAllText(@"C:\Users\cmcintosh\Documents\Visual Studio 2013\Projects\ConsoleApplication1\names.json");

			var readCollection = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileValue);
			string readJson = JsonConvert.SerializeObject(collection, Formatting.Indented);

			Console.WriteLine(readJson);
			Console.ReadLine();

			
		}
	}
}
