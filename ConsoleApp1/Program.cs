namespace ConsoleApp1
{
    internal class Program
    {
        class Kujund { }
        class Ring : Kujund { public double Raadius; }
        class Ruut : Kujund { public double Küljepikkus; }
        class Kolmnurk : Kujund { public double Kõrgus; public double Alus; }
        class Ristkülik : Kujund { public double Kõrgus; public double Laius; }


        static (int sum, int count) Arvuta(IEnumerable<int> arvud)
        {
            int s = 0; int c = 0;
            foreach (int _ in arvud) { c++; s += _; }
            return (s, c);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // range objekt ja selle kasutamine
            int[] arvud = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var osa = arvud[3..];
            Console.WriteLine(string.Join(", ", osa));

            // switch avaldis
            var np = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Sunday => "pühapäev",
                DayOfWeek.Saturday => "saunapäev",
                DayOfWeek.Wednesday => "trennipäev",
                _ => "misiganes"
            };

            var pilt = new List<Kujund>
            { new Ring  { Raadius = 1},
            new Ruut { Küljepikkus = 1},
            new Kolmnurk { Kõrgus = 2, Alus = 1},
            new Ristkülik { Kõrgus = 2, Laius = 1},
            };

            double pindala = 0;
            foreach(Kujund ku in pilt)
            {
                pindala += ku switch
                {
                    Ring ring => ring.Raadius * ring.Raadius * Math.PI,
                    Ruut r => r.Küljepikkus * r.Küljepikkus,
                    Kolmnurk k => k.Alus * k.Kõrgus / 2,
                    Ristkülik r => r.Kõrgus * r.Laius ,
                     _ => 0
                }; 
            }


            (int ss, _) = Arvuta(arvud);
            // _ mulükskõik nimeline muutuja




        
        
        }

        

    }
}
