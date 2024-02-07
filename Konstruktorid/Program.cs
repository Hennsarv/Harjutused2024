using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktorid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inimene henn = new Inimene( new DateTime (1955,3,7 ));
            Inimene tita = new Inimene("Väikepeebi");

            // tupplid
            (int x, int y) punkt = (3, 4);
            



        }
    }

    class Inimene
    {
        private string nimi;
        

        public string Nimi {get=> nimi; set => nimi = value; }

        public DateTime Sünniaeg { get; private set; }  

        // konstruktor - new operatsiooni ajal käivitatakse
        // meetod mille nimi == klassinimi

        public Inimene(DateTime sünniaeg) : this("tundmatu", sünniaeg) { }


        public Inimene() { Sünniaeg = DateTime.Now; }

        public Inimene(string nimi) : this() // construktorite sidumine
        => Nimi = nimi;


        public Inimene(string nimi, DateTime sünniaeg) => (Nimi, Sünniaeg) = (nimi, sünniaeg);
        //{
        //    Nimi = nimi;
        //    Sünniaeg = sünniaeg;
        //}


    }
}
