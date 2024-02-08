using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kollektsioonid
{
    public enum Mast { Risti, Ruutu, Ärtu, Poti}
    public enum Kaart
    {
        Kaks, Kolm, Neli, Viis, Kuus, Seitse, Kaheksa, Üheksa, Kümme,
        Soldat, Emand, Kuningas, Äss
    }

    public class PlayCard { 
        public Mast Mast; 
        public Kaart Kaart;
        public PlayCard(int x) => (Mast, Kaart) = ((Mast)(x / 13), (Kaart)(x % 13));
        private PlayCard(Mast mast, Kaart kaart) => (Mast, Kaart) = (mast, kaart);
        public override string ToString() => $"{Mast} {Kaart}";

        public static implicit operator PlayCard(int x) => new PlayCard(x);

        public static PlayCard Parse(string s)
        /*{
        //    var t = s.Split(' ');
        //    Mast m = (Mast)Enum.Parse(typeof(Mast), t[0]);
        //    Kaart k = (Kaart)Enum.Parse(typeof (Kaart), t[1]);
        //    return new PlayCard(m, k);
        //}*/
        => new PlayCard(
                (Mast)Enum.Parse(typeof(Mast), s.Split(' ')[0]), 
                (Kaart)Enum.Parse(typeof(Kaart), s.Split(' ')[1]));

//        public static bool TryParse(string s, out PlayCard m) 
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            
            PlayCard mk = new PlayCard(20);
            PlayCard tmk = 20;
            string kaart = "Risti Kuningas";
            PlayCard kmk = PlayCard.Parse(kaart);   
            
            
            int[] ints = { 1, 2, 3, 4, 5, };

            decimal esimene = 7;
            decimal teine = 8;
            Console.WriteLine($"{esimene}-{teine} ");
            Vaheta(ref esimene, ref teine);
            Console.WriteLine($"{esimene}-{teine} ");

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, };

            foreach (int i in list) Console.Write($"{i}, ");
            Console.WriteLine();
            list.Add(12); // 8 järele läheb 12
            list.Remove(5); // keskelt 5 nopitakse ära (kui listis on mitu, sisi vaid esimene)
            list.RemoveAt(1); // list teine element (2) korjatakse ära

            foreach (int i in list) Console.Write($"{i}, ");
            Console.WriteLine();

            list = new List<int>(80) { };
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
                Console.WriteLine($"{list.Count} - {list.Capacity}");
            }



            List<string> list2 = new List<string>() { };
            List<decimal> list3 = new List<decimal>() { };

            List<(int a, int b)> list4 = new List<(int a, int b)>();

            list4.Add((3, 4));
            //            Console.WriteLine( string.Join(", ", list));

            int[] arr = list.ToArray();
            var uuslist = arr.ToList();

            // sissejuhatus generic collektsioonidesse

            Stack<int> stack = new Stack<int>(); // LIFO
            Queue<int> q = new Queue<int>();    // Last In First Out

            stack.Push(1);
            stack.Push(7);
            stack.Push(8);
            stack.Push(7);
            stack.Push(9);
            Console.WriteLine(string.Join(", ", stack));

            Console.WriteLine($"võtam pakist {stack.Pop()}");
            Console.WriteLine($"võtam pakist {stack.Pop()}");
            Console.WriteLine($"võtam pakist {stack.Pop()}");

            q.Enqueue(1);           // FIFO
            q.Enqueue(7);           // First In First Out
            q.Enqueue(8);
            q.Enqueue(7);
            q.Enqueue(9);
            Console.WriteLine(string.Join(", ", q));
            Console.WriteLine($"võtam pakist {q.Dequeue()}");
            Console.WriteLine($"võtam pakist {q.Dequeue()}");
            Console.WriteLine($"võtam pakist {q.Dequeue()}");

            // keeruline kollektsioon
            Dictionary<string, DateTime> sünnipäevad
                = new Dictionary<string, DateTime>()
                {
                    {"Henn", new DateTime(1955,3,7) },
                    {"Ants", new DateTime(1966,4,9) },
                    {"Peeter", new DateTime(1890,11,2) },
                    {"Joosep", new DateTime(1972,1,3) },
                    {"Karla", new DateTime(1944,5,6) },
                };

            //            Console.WriteLine(sünnipäevad["Polla"]);

            Console.WriteLine(sünnipäevad.TryGetValue("Peeter", out var d1) ? d1 : DateTime.MinValue);
            Console.WriteLine(sünnipäevad.TryGetValue("Polla", out var d2) ? d2 : DateTime.MinValue);

            Console.WriteLine("\nsõnastikus olevad võtmed - Keys");
            Console.WriteLine(string.Join(", ", sünnipäevad.Keys));

            Console.WriteLine("\nsõnastikus olevad andmed - Values");
            Console.WriteLine(string.Join(", ", sünnipäevad.Values));

            Console.WriteLine("\nsõnastikus olevad asjad - (Key,Value) paarid");
            Console.WriteLine(string.Join(", ", sünnipäevad));

            // põhiliosed kollektsioonid on üle vaadatud

            

            Random R = new Random();
            List<int> segamatapakk = Enumerable.Range(0, 52).ToList();
            List<int> segatudpakk = new List<int>(52);
            while (segamatapakk.Count > 0)
            {
                int i = R.Next(segamatapakk.Count);  // R.Next() % segamatapakk.Count
                segatudpakk.Add(segamatapakk[i]);
                segamatapakk.RemoveAt(i);
            }

            Console.WriteLine("\nsegatud pakk\n");
            for (int i = 0; i < segatudpakk.Count; i++)
            {
                //Console.Write($"{(Mast)(segatudpakk[i] / 13)} {(Kaart)(segatudpakk[i] % 13)}\t\t" + (i % 4 == 3 ? "\n" : ""));
                Console.Write($"{ (PlayCard)segatudpakk[i]}{(i % 4 == 3 ? "\n" : "\t\t")}"   ) ;
            }

            // täna õhtul oskaks teha nii


            // segame paki (arvud 0..51)
            var segatud = 
                Enumerable.Range(0, 52)
                //.AsEnumerable()
                .OrderBy(x => R.NextDouble())
                .ToList();
            var jagatud = Enumerable.Range(0, 4)
                .Select(x => segatud
                            .Skip(x * 13)
                            .Take(13)
                            .OrderByDescending(y => y)
                            .ToList())
                .ToList();

            Console.WriteLine("\nteine segatud ja jagatud pakk\n");

            Console.WriteLine("Põhi\t\t\tIda\t\t\tLõuna\t\t\tLääs");
            Console.WriteLine(new string('-', 100));
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{(PlayCard)jagatud[j][i]}\t\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //foreach(PlayCard pc in segatudpakk) { Console.WriteLine(pc); }

        }

        //static void Vaheta(ref int a, ref int b)
        //{
        //    int c = a; a = b; b = c;
        //    (b, a) = (a, b);
        //}

        //static void Vaheta(ref decimal a, ref decimal b) => (a, b) = (b,a);

        // generic funktsioon
        static void Vaheta<T>(ref T a, ref T b) //=> (a,b) = (b,a);
        {
            T c = a;
            a = b;
            b = c;
        }

    }
}
