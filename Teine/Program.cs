using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teine
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int ridu = 11;
            int veerge = 5;

            int[] arvud = new int[ridu * veerge];
            Random rand = new Random();
            for (int i = 0; i < arvud.Length; i++) arvud[i] = rand.Next() % 100;

            Console.Write("Veerud\t\t|\t");
            for (int i = 1; i <= veerge; i++) Console.Write($"{i,3:0}\t");

            Console.WriteLine("\n" + new string('-', 20 + veerge * 8));

            for (int i = 0; i < arvud.Length;)
                Console.Write($"{(i % veerge == 0 ? $"Rida {i / veerge + 1,2:0}:\t|\t" : "\t")}{arvud[i],3:0}{(++i % veerge == 0 ? "\n" : "")}");
            //                  kui 1. veerg        siis pane reanumber                sisu (3 kohta)  kui on viimane veerg
            Console.WriteLine(new string('-', 20 + veerge * 8));
            Console.WriteLine("\nOtsime 55\n");

            bool leitud = false;

            for (int i = 0; i < arvud.Length; i++)
            {
                if (arvud[i] == 55)
                {
                    leitud = true;
                    Console.WriteLine($"leidsin reast {i / ridu + 1} ja veerust {i % ridu + 1}");
                }

            }
            if (!leitud) Console.WriteLine("ei leidnudki");
        }
    }
}
