using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staatikud
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Inimene henn = new Inimene { EesNimi= "Henn", PereNimi = "Sarv", Palk = 800};
            Inimene.MiinimumPalk = 400;
            Inimene ants = new Inimene { EesNimi = "Ants", PereNimi = "Saunamees", Palk = 500 };
            Inimene.MiinimumPalk = 4000;
            Inimene Pealik = henn;

            Console.WriteLine(henn);
            Console.WriteLine(ants);

            henn.Palk -= 100;
            ants.Palk -= 100;
            

            Console.WriteLine(henn);
            Console.WriteLine(ants  );

        }
    }

    class Inimene
    {
        static decimal _miinimumPalk = 1000;
        // staatilised väljad on kamba peale ühised (üks eksemplar igat)
        // Inimene.Miinimumpalk

        // static property
        public static decimal MiinimumPalk
        {
            get => _miinimumPalk; 
            set => _miinimumPalk = value < _miinimumPalk ? _miinimumPalk : value;
        }

        public string EesNimi { get; set; }
        public string PereNimi {  get; set; }

        public string TäisNimi { get { return $"{EesNimi} {PereNimi}"; } }

        decimal palk = MiinimumPalk;
        public decimal Palk {  get => palk; 
            set => palk = 
                  value > palk ? value // uus palk on senisest suurem - siis OK
                : value < MiinimumPalk ? MiinimumPalk  // uus palk < miinimum - siis võtame miinimumi
                : palk  ; }

        public override string ToString() => $"{TäisNimi} saab palka {Palk}";
        

    }

}
