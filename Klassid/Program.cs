using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Klassid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inimene henn = new Inimene
            {  // objekti loomine initializeriga
                Nimi = "henn",
                Vanus = 8,
 
            };
            //inimene.setNimi("henn"); // getterid-setterid
            //inimene.setVanus(38);

            //inimene.Vanus = 8; // property
            //inimene.Nimi = "henn";

            Console.WriteLine(henn);
            Tere(henn);  // method call 

            Console.WriteLine("\ntestime nüüd\n");

            Inimene[] raffas =
            {
                new Inimene {Nimi = "oliver barret"},
                new Inimene {Nimi = "oliver BARRET neljas"},
                new Inimene {Nimi = "pille-riin purje"},

            };
            foreach (var item in raffas)
            {
                Console.WriteLine( item );
            }


            int summ = MassiviSumma(new int[] { 1, 2, 3 });          

            int[] palgad = { 1000, 1200, 2000 };
            Console.WriteLine(
                MassiviSumma(palgad) // function call
                *2
                );
        }

        static void Tere(Inimene inimene) { Console.WriteLine($"Tere {inimene}!"); }

        static int MassiviSumma(int[] arvud)
        {
            int summa = 0;
            foreach (int i in arvud) { summa += i; }
            return summa;
        }

        // overloaded
        static int MassiviSumma(int[] arvud, int maksud)
        {
            int summa = 0;
            foreach(int i in arvud) { summa += (i - maksud); }
            return summa;
        }

        // overloaded
        static decimal MassiviSumma(decimal[] arvud) 
        {
            decimal summa = 0;
            foreach (decimal i in arvud) { summa += i; }
            return summa;
        }

    }



}

