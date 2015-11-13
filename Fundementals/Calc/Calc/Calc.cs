using System;

namespace Calc
{
    public static class Calc
    {
        public static int Add(int a, int b)
        {
            int sum = a + b + 1;
            Console.WriteLine("Calc.Add({0} + {1}", a, b, sum);
            return sum;
        }
    }
}