using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
namespace CSVDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\sarvi\OneDrive\PowerBI\sqlcsv\categories.csv";
            
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    foreach (var property in record)
                    {
                        Console.Write(property.Key + "=" + property.Value + " ");
                    }

                    Console.WriteLine();
                }
            }

        }
    }
}
