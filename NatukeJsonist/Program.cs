using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;


namespace NatukeJsonist
{
    public class Inimene
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; }

        public DateTime Sünniaeg { get; set; }

        public string Omadus { get; set; }

        public override string ToString() => $"{Omadus} inimene {Nimi} vanusega {Vanus}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = @"..\..\Henn.json";
            string filenameRaff = @"..\..\Raffas.json";
            Inimene inimene = new Inimene
            {
                Nimi = "Henn\nSarv",
                Vanus = 68,
                Sünniaeg = new DateTime(1955, 3, 7),
                Omadus = "tubli"
            };
            /*
            //Console.WriteLine(inimene);
            //var ser = new XmlSerializer(typeof(Inimene));
            //TextWriter tw = new StringWriter();
            //ser.Serialize(tw, inimene);
            //string s = tw.ToString();

            //TextReader tr = new StringReader(s);

            //Inimene ihii = (Inimene) ser.Deserialize(tr );

            //Console.WriteLine(ihii);
            */

            /*
            string json = JsonConvert.SerializeObject(inimene);
            Console.WriteLine(json);
            File.WriteAllText(filename, json);

            List<Inimene> raffas = new List<Inimene>
            {
                new Inimene
                {
                    Nimi = "Henn\nSarv",
                    Vanus = 68,
                    Sünniaeg = new DateTime(1955, 3, 7),
                    Omadus = "tubli"
                },
                new Inimene
                {
                    Nimi = "Joosepson",
                    Vanus = 68,
                    Sünniaeg = new DateTime(1966, 1, 31),
                    Omadus = "mitteniitubli"
                },

            };

            var raff = JsonConvert.SerializeObject(raffas);
            Console.WriteLine(raff);
            File.WriteAllText(filenameRaff, raff);
            */

            string loeInimene = File.ReadAllText(filename);

            var ihii = JsonConvert.DeserializeObject<Inimene>(loeInimene);
            Console.WriteLine(ihii);

            string loeRaffas = File.ReadAllText(filenameRaff);

            var ohoo = JsonConvert.DeserializeObject<Inimene[]>(loeRaffas);
            int nr = 0;
            foreach(var i in ohoo) Console.WriteLine($"{++nr}. {i}");

            dynamic dohoo = JsonConvert.DeserializeObject(loeRaffas);
            foreach (dynamic i in dohoo) Console.WriteLine($"{++nr}. {i}");





        }
    }
}
