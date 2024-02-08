using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VeelKlassidest
{
    public static class E
    {
        public static void NäitaNime(this Inime x) => Console.WriteLine(x.Nimi);

        public static string ToProper(this string str) 
            => str.Substring(0,1).ToUpper() + str.Substring(1).ToLower();

        public static int MyParse(this string str) => int.Parse(str);

        public static void Õnnitlus(string x) => Console.WriteLine($"Palju õnne sulle, {x}!");
    }
    
    internal class Program
    {
        

        static void Main(string[] args)
        {
            /*
                Meil oleks vaja klassidest veel mõned asjad rääkida, et saaks teha kokkuvõtte
                Meil on räägitud

                    Klass, Klassi liikmed
                    Väljad (või muutujad)
                    Propertid
                    Funktsioonid-meetodid
                    Staatilised-Mittestaatilised
                    Konstruktorid
            
            Räägime veel
                    Eventid
                    Extensionid
                    Linq

            Lisaks teeme ühe projekti veel, kus räägime tuletatud klassidest
                    
            */
        
            //Inime henn = new Inime { Nimi = "Henn"};
            Inime henn = new Inime();
            henn.Nimi = "henn";

            //henn.TrükiNimi();   // . member call operatsioon
            //Inime.PrindiNimi(henn);
            //E.NäitaNime(henn);
            //henn.NäitaNime();

            //Action<string> Tere = x => Console.WriteLine($"Tere {x}!");
            //Action<string> Taega = x => Console.WriteLine($"Headaega {x}!");

            henn.Vanus = 60;
            Inime ants = new Inime { Nimi = "Ants", Vanus = 55 };

            henn.Õnnitlus += E.Õnnitlus;
            henn.Õnnitlus += (x) => Console.WriteLine($"{x} - sina saad nimelise kella ");
           ants.Pension += (string x) => Console.WriteLine($"{x} mine pensile sa juba küllalt vana");
            ants.Õnnitlus += E.Õnnitlus;

            for (int i = 0; i < 20; i++) { 
                henn.Vanane();
                ants.Vanane();
            }

            henn.Õnnitlus -= E.Õnnitlus;

            for (int i = 0; i < 40; i++)
            {
                henn.Vanane();
                ants.Vanane();
            }





        }
    }

    public class Inime
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; } = 0;

        // eventid
        public Action<string> Pension = null; // muutuja millele saab lisada fuktsioone
        public Action<string> Õnnitlus = null; // mis siis vajadusel välja kutsutakse


        public void Vanane()
        {
            Vanus++;
                            // programm otsustab, mis juhul event välja kutsutakse (invoke)
            if (Vanus > 65) if(Pension != null) Pension.Invoke(Nimi);
            if (Vanus % 25 == 0) Õnnitlus?.Invoke(Nimi);
                            // event händleri väljakutsumisel tuleb veenduda, et see on olemas
        }

        public void TrükiNimi() => Console.WriteLine(E.ToProper(this.Nimi));

        public static void PrindiNimi(Inime inime) => Console.WriteLine(inime.Nimi.ToProper()); 
    }


}
