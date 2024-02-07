using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LisaksKlassidele
{
    public enum Mast { Risti , Ruutu, Ärtu, Poti, Pada = 3}
    public enum Kaart { Äss, Kaks, Kolm, Neli, Viis, Kuus, Seitse, Kaheksa, Üheksa, Kümme, Soldat, Emand, Kuningas }

    [Flags]
    public enum Tunnus { Puust = 1, Punane = 2, Suur = 4, Koliseb = 8 }

    internal class Program
    {
        static void Main(string[] args)
        {
            Mast mast = Mast.Ärtu;
            Console.WriteLine( mast );
            mast++;
            Console.WriteLine( mast);

            Random R = new Random();

            for ( int i = 0; i <52 ; i++ ) 
            {
                int k = R.Next() % 52;
                Console.WriteLine($"{(Mast)(k/13)} {(Kaart)(k%13)}");
            }

            // mõtle välja kuidas teha segatud kaardipakk


            Mast x = (Mast)Enum.Parse(typeof(Mast), "Risti");
            Console.WriteLine( x );

            Console.WriteLine((Tunnus)13);

            Tunnus t = Tunnus.Punane | Tunnus.Puust | Tunnus.Koliseb;
            Console.WriteLine((int)t);

            t |= Tunnus.Suur; Console.WriteLine(t );

            t ^= Tunnus.Koliseb; Console.WriteLine(t);

            if ((t & Tunnus.Puust) == Tunnus.Puust) Console.WriteLine("oli puust");

        }
    }
}
