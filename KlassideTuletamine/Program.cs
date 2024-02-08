using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KlassideTuletamine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loom l = new Loom("metsakutsa");
            //l.TeeHäält();

            Koduloom kl = new Koduloom("Ants", "prussakas");
            //kl.TeeHäält();

            Koer pauka = new Koer("Pauka");
            //pauka.TeeHäält();

            List<Loom> loomaaed = new List<Loom>()
            { l, kl, pauka};

            foreach(var x in loomaaed) { x.TeeHäält(); }

            Kass murri = new Kass("Murri");
            murri.TeeHäält();

            murri.SikutaSabast();
            murri.TeeHäält();

            Sepik sepik = new Sepik();
            Lõuna(sepik);

            foreach (var x in loomaaed) Lõuna(x);
            


        }

        static void Lõuna(object x)
        {
            if (x is Loom l) l.TeeHäält();
            if (x is ISöödav ix) ix.Süüakse();

            //ISöödav iii = x as ISöödav; // iii = x is ISöödav ? (ISöödav)x : null;
            (x as ISöödav)?.Süüakse();
        }
            

    }


    interface ISöödav
    {
        void Süüakse();
    }

    class Sepik : ISöödav
    {
        public void Süüakse()
        {
            Console.WriteLine("keegi nosib sepikut");
        }
    }

    class Loom
    {
        protected readonly string liik;
        public string Liik { get; }
        public Loom(string liik) { this.liik = liik; }
        public Loom() : this("tundmatu") { }
        public virtual void TeeHäält() => Console.WriteLine($"Loom liigist  {liik} teeb koledat häält"); 

    }

    //abstract 
    class Koduloom : Loom
    {
        public string Nimi { get; set; }
        public Koduloom(string nimi, string liik) : base(liik) { this.Nimi = nimi;}

        public override void TeeHäält() =>
        Console.WriteLine($"{Nimi} ({liik}) teeb mõnusat häält");

        //public abstract void VõtameArvele(); // see meetod TULEB üle defineerida Kassi ja Koera klassis

    }

    class Koer : Koduloom, ISöödav
    {
        public string Tõug { get; set; } = "krants";

        public Koer(string nimi) : base(nimi, "koer") { }

        public override void TeeHäält() =>
        Console.WriteLine($"{Tõug} {Nimi} ({liik}) haugub");

        public void Süüakse()
        {
            Console.WriteLine($"peni {Nimi} pistetakse nahka"); 
        }
    }

    class Kass : Koduloom
    {
        private bool tuju = true;
        public string Tõug { get; set; } = "";
        public Kass(string nimi) : base(nimi, "kass") { }

        public override void TeeHäält()
        {
            if (tuju) Console.WriteLine($"Kiisu {Nimi} lööb nurrru!");
            else Console.WriteLine($"Kass {Nimi} kräunub");
        }

        public void SikutaSabast() => tuju = false;
        public void Silita() => tuju = true;
    }
}
