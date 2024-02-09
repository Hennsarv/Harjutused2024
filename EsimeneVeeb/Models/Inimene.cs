using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsimeneVeeb.Models
{
    public class Inimene
    {
        public static Dictionary<int,Inimene> Rahvas = 
            new Dictionary<int, Inimene>
            {
                {1, new Inimene{id = 1, Nimi = "Henn", Vanus = 69} },
                {2, new Inimene{id = 2, Nimi = "Ants", Vanus = 44}},
                {3, new Inimene{id = 3, Nimi = "Peeter", Vanus = 33} },
                {4, new Inimene{id = 4, Nimi = "Jaak", Vanus = 11} },
            }
            ;

        public int id = 0;
        public string Nimi { get; set; }
        public int Vanus { get; set; }
    }
}