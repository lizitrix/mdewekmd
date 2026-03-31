using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("введите х");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите y");
            double y = Convert.ToDouble(Console.ReadLine());

            double z = Math.Pow(x, Math.Pow(y, 2) + 3 * y - 5) + Math.Atan(Math.Pow(y, 4));

            Console.WriteLine("для х={0:f4} и у={1:f4}", x, y);
            Console.WriteLine("результат ={0:f4}", z);
        }
    }
}

