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
            Console.WriteLine(uri.GetType().Assembly.FullName);
            Console.WriteLine(typeof(Program).Assembly.FullName);
            Console.WriteLine(typeof(Calc.Calc).Assembly.CodeBase); // Where CLR found this assembly 
            Console.WriteLine(typeof(Calc.Calc).Assembly.Location); // Where CLR actaully loaded this assembly from

            Console.WriteLine(typeof(Calc.Calc).AssemblyQualifiedName);

            //Console.ReadKey();
        }
    }
}