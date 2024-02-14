using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Nihutamised
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte b = 0b1000_1111;

            b >>= 1;
            Console.WriteLine("{0:x2}", b);

            bitArray ba = new bitArray(32);
            Console.WriteLine(ba);
            ba[7] = true;
            ba[8] = true;
            Console.WriteLine(ba);

            BigInteger bigInteger = int.MaxValue;
            Console.WriteLine(bigInteger*bigInteger);
//            for (int i = 0; i < 10; i++) { bigInteger *= bigInteger; }

            bigInteger = 1;
            for (int i = 0;i < 1000; ) { bigInteger *= (++i); }
            Console.WriteLine(bigInteger);


        }
    }

    internal class bitArray
    {
        private uint[] sisu;

        public bitArray(int suurus)
        {
            sisu = new uint[suurus / 32 + 1];
        }

        public bool this[int index]
        {
            get
            {
                if (index > sisu.Length * 32) throw new IndexOutOfRangeException();
                return ((sisu[index / 32] & (1 << (index % 32))) == 1);
            }

            set
            {
                if (value)
                {
                    sisu[index / 32] |= 1u << index % 32;
                }
                else
                {
                    sisu[index / 32] &= ~(1u << index % 32);
                }
            }

        }

        public override string ToString()
        {
            return string.Join(" ", sisu.Select(x => $"{x:x8}"));
        }

    }
}
