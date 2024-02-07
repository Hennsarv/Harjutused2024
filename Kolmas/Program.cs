using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // täna siis kolmapäev - täna teisendame

            //Console.Write("Anna üks arv: ");
            //int a = int.Parse(Console.ReadLine());


            //if (int.TryParse(Console.ReadLine(), out int a))
            //{
            //    Console.WriteLine($"sinu antud arvu {a} ruut on {a * a}");
            //}
            //else
            //    Console.WriteLine("see pole miski arv");

            //int b = int.TryParse(Console.ReadLine(), out int x) ? x : 0;

            Console.Write("Millal sa oled sündinud: ");
            string sünnipäev = Console.ReadLine();

            //Console.WriteLine( DateTime.Parse(sünnipäev).DayOfWeek);

            Console.WriteLine(
                DateTime.TryParse(sünnipäev, out DateTime d) 
                ? d.ToString("(dddd) dd.MM.yyyy") 
                : "ahah");

            int ix = 789;
            Console.WriteLine(ix.ToString("0000"));

            for (int i = 69; i < 127; i+=11) {
                //   Console.WriteLine(i.ToString("0 ")); 
                Console.WriteLine( "{0,5:D}", i );

                String.Format("{0,5:DD}", i);
            }



        }
    }
}
