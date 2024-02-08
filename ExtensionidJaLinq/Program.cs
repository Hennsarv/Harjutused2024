using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionidJaLinq
{
    static class E
    {
        public static IEnumerable<int> Paaris(this IEnumerable<int> m)
        {
            foreach (int i in m) if (i % 2 == 0) { yield return i; }
        }

        //public static bool KasPaaris(int x) => x % 2 == 0; 
        
        public static IEnumerable<T> Kas<T>(this IEnumerable<T> m, Func<T,bool> kas) 
        { 
            foreach(T i in m) if (kas(i)) yield return i;
        }

        public static IEnumerable<int> Võta(this IEnumerable<int> m, int mitu)
        {
            int i = 0;
            foreach (var x in m)
            {
                if (++i > mitu) break;
                yield return x;
            }
        }

        public static IEnumerable<T> Jäta<T>(this IEnumerable<T> m, int mitu)
        {
            int i = 0;
            foreach (var x in m)
            {
                if (i++ < mitu) continue;
                yield return x;
            }
        }

        /// <summary>
        /// see tõmbab kollektsioone stringiks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m"></param>
        /// <param name="sep"></param>
        /// <returns></returns>
        public static string StrJoin<T>(this IEnumerable<T> m, string sep) => String.Join(sep, m);

        public static string ToFormat<T>(this T t, Func<T,string> format) => format(t);

        public static void CWL(this string str, string prefix = "", string suffix = "") 
            => Console.WriteLine($"{prefix}{str}{suffix}");
        


    }

    internal class Program
    {
        static void Main(string[] args)
        {
                int[] ints = { 1, 2, 3, 7, 8 , 11, 10, 12, 13, 6, 1 };

            //Func<int, bool> k = (int x) => x % 2 == 0;

                foreach (int i in ints
                .Where((int x) => x % 2 == 0)
                .Skip(2)
                .OrderBy(x => x)

                ) Console.WriteLine(i);

            // LINQ - language integrated query
            var xL = (from x in ints where x < 10 select x).ToList();  // LINQ kujul
            var yL = ints.Where(x => x < 10).Select(x => x).ToList();  // extension kujul

            // select lahtiseletus

            var xxx = new { Nimi = "Henn", Vanus = 68 };
            
            foreach (var xx in ints
                .Select(x =>  new  { Arv = x, Ruut = x*x})
                ) Console.WriteLine( xx   );

            (from x in ints select new { x, Ruut = x * x })
                .StrJoin("; ")
                .CWL();

            ints
                .Select(x => new { x, Ruut = x * x }) // taome arvud arvupaarideks
                .StrJoin("; ")   // paneme nad ühte viirgu
                .CWL();  // tulistame välja


            var sünnipäevad = new Dictionary<string, DateTime>
            {
                {"Henn", new DateTime(1955,3,7) },
                {"Ants", new DateTime(1966,4,4) },
                {"Peeter", new DateTime(194,5,5) },
                {"Joosep", new DateTime(1988,1,1) },
                {"Jüri", new DateTime(1999,2,2) },
                {"Malle", new DateTime(2001,2,28) }
            };

            // kõige vanem
            sünnipäevad
                .OrderBy(x => x.Value)
                .FirstOrDefault()
                .ToString()
                .CWL(suffix: " on kõige vanem");
            sünnipäevad
                .OrderByDescending(x => x.Value)
                .FirstOrDefault()
                .ToString()
                .CWL(suffix: " on kõige noorem", prefix: "Tema: ");

            sünnipäevad
                .Select(x => new { nimi = x.Key, birthday = new DateTime(DateTime.Now.Year, x.Value.Month, 1).AddDays(x.Value.Day-1)  })
                .Select(x => new { x.nimi, birthday = x.birthday < DateTime.Today ? x.birthday.AddYears(1) : x.birthday })
                .OrderBy(x => x.birthday)
                .FirstOrDefault()
                .ToFormat(x => $"{x.nimi} {x.birthday:dd.MMMM}")
                .CWL(prefix: "järgmine sünnipäevalaps: ");
        }



    }

}
