using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamikud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 77;
            string s = "miski jutt";

            string test = 
@"esimene rida
teine rida
kolmas rida
";
            foreach(string rida in test.Replace("\r","").Split('\n')) 
            { Console.WriteLine($"=={rida}*"); }

            Console.WriteLine("\nfailis\n");

            foreach(string rida in System.IO.File.ReadAllText(@"C:\Users\sarvi\source\repos\Harjutused2024\Dynamikud\TextFile1.txt").Split('\n'))
            {
                Console.WriteLine($"=={rida}*");
            }

            StringReader sr = new StringReader(test);
            while(true)
            {
                string r = sr.ReadLine();
                if (r == null) break;
                Console.WriteLine($"=={r}*");
            }

        }
    }
}
