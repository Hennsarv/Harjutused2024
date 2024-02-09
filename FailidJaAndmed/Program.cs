using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace FailidJaAndmed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Räägime mis on failid ja kuidas nendega ringi käiakse
             * Vaatame, kuidas lugeda ja kirjutada faile, nende sisu
             * Proovime CSV ja JSON (kes tahab ka XML) failidega mängida
             * 
             * ja seejärel proovime
             * 
             * kas ja kuidas ja miks toimetada andmebaasidega
             * 
             * Datareaderiga
             * Linq to DB
             * Entity FW abiga
             * 
             * ja siis mõtleme, mis me võiks nädalavahetusel ise valmis ehitada
             * 
             */

            string directoryname = @"..\..\";
            string filename = "products.csv";
            string pathname = Path.Combine(directoryname, filename);

            string fileout = "tooted.csv";
            string pathOut = Path.Combine(directoryname, fileout);

            //            Console.WriteLine(File.ReadAllText(pathname)); // üks pikk string

            // readalllines - loeb korraga string[]
            // readline - loeb 1haaval tsükli (enumerable) läbimisel

            var read = File.ReadLines(pathname); // stringi enumeraabel
                                                 //foreach (var line in read
                                                 //    .Where(x => x.Length > 0) // jätame tühjad read vahele
                                                 //    ) ;

            //File.WriteAllLines(pathOut,
            //    read
            //    .Skip(0) // jätame ära esimese rea -- mitu rida 1

            //    .Where(x => x.Length > 0) // jätame vahele tühjad read
            //    .Take(10)
            //    );

           File.WriteAllLines(pathOut,
            read
                .Skip(1)
                .Where(x => x.Length > 0) // jätame vahele tühjad read
                .Select(x => x.Replace("\",", "\";"))
                .Select(x => x.Split(';').Select(y => y.Replace("\"", "")).ToArray())
                .Select(x => new { Tootenimi = x[1], Hind = (Decimal.TryParse(x[5], out decimal h) ? h : 0) })
                //.ToList()
                //.ForEach(x => Console.WriteLine(x));
                .Select(x => x.ToString())
                
                );






            ;



        }
    }
}
