using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamikud
{
    class Bag : DynamicObject
    {
        private dynamic bag = null;

        public Bag() => bag = new Dictionary<string, dynamic>();
        public Bag(Dictionary<string,dynamic> bag) => this.bag = bag;

        public override bool TryGetMember(GetMemberBinder binder, out dynamic result)
        {
            result = bag.ContainsKey(binder.Name) ? bag[binder.Name] : null;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bag[binder.Name] = value;
            return true;
        }

        public override string ToString()
        {
            if (bag == null || !(bag is IDictionary<string, object>)) return null;
            Dictionary<string,dynamic>.KeyCollection keys =  bag.Keys;

            return "{" +
            string.Join(", ",
            keys.Select(key => $"{key}={bag[key]}"))
            + "}";
            ; 
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 77;
            string s = "miski jutt";

            Console.WriteLine(s);
            Console.WriteLine(i);

            Object[] asjad = new Object[] { s, i };

            object o = i;

            Console.WriteLine(o.GetType().Name);
            
            int j = (int)o;

            dynamic d = s;

            d = d.ToUpper();
            Console.WriteLine(d);

            dynamic bag = new Bag();

            bag.nimi = "Henn";
            bag.vanus = 68;
            bag.Kodu = "Mõnistes";
            bag.kodu = "Männikul";
            bag.vanus++;
            Console.WriteLine(bag);

        }
    }
}
