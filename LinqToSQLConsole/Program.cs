using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQLConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NWDataContext db = new NWDataContext();

            /*
                        db.Log = Console.Out;

                        var categories = db.Categories
                            //.Where(x => x.CategoryID < 4)
                            .OrderBy(x => x.CategoryName)
                        //    .ToArray();
                            ;

                        var kt = db.Categories.Where(x => x.CategoryID == 8).Single();

                        Console.WriteLine(  kt.CategoryName);
                        kt.CategoryName = "Seatoit";

                        db.SubmitChanges();


                        Console.WriteLine("\nmeil on sellised kategooriad\n");
                        foreach (var c in categories) 
                        {
                            Console.WriteLine(c.CategoryName);
                        }


                        db.Products.Select(x => new { x.ProductName, x.UnitPrice, x.Category.CategoryName })
                            //.ToList().ForEach(x => Console.WriteLine(x)) ;
                            ;
            */

            var q1 = db.Products
                .Where(x => x.UnitPrice < 20)
                .Where(x => !x.Discontinued)
                .OrderByDescending(x => x.UnitPrice * x.UnitsInStock)
                .ToList();
                ;

            var q2 = (from x in db.Products
                     where x.UnitPrice < 20
                     where !x.Discontinued
                     orderby x.UnitPrice * x.UnitsInStock descending
                     select x)
                     .ToList();
                     ;

        }
    }
}
