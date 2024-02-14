// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


byte b = 0b1000_1111;

sbyte s = (sbyte)b;

s >>>= 1;
Console.WriteLine("{0:x2}", s);

