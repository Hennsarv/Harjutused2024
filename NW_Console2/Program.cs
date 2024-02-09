using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Console2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities2 db = new NorthwindEntities2();
            db.Categories.ToList().ForEach(c => Console.WriteLine(c.CategoryName));

            db.Categories.Find(8).CategoryName = "Seafood";
            db.SaveChanges();

            





        }
    }
}
