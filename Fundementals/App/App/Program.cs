using System;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "http://www.google.com";
            Uri uri = new Uri(url);

            Console.WriteLine(url.GetType().Assembly.FullName);
            Console.WriteLine(typeof(Program).Assembly.FullName);
            Console.WriteLine(typeof(Calc.Calc).Assembly.CodeBase); // Where CLR found this assembly 
            Console.WriteLine(typeof(Calc.Calc).Assembly.Location); // Where CLR actaully loaded this assembly from

            Console.WriteLine(typeof(Calc.Calc).AssemblyQualifiedName);

            //Console.ReadKey();

            B b1 = new B();         // OK
            D d1 = new D();         // OK
            B b2 = new D();         // OK - can not call D's methods
           // B b3 = new Object();    // CTE - base to derived
            B b4 = d1;              // OK - derived to base - implicit
           // D d3 = b2;              // CTE - base to derived
            D d4 = (D)d1;           // OK - D to D,
            D d5 = (D)b2;           // OK - b2 points to new D(), explicit
            D d6 = (D)b1;           // RTE - b1 points to new B(), run time error
            B b6 = (B)b2;           // OK - b2 points to new D()
        }
    }

    public class B
    {
        public B()
        {
            First = "first";
        }

        public string First { get; set; }
    }

    public class D : B
    {
        public D()
        {
            Second = "second";
        }

        public string Second { get; set; }
    }
}