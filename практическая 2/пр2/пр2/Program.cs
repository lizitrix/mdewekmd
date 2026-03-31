using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите x");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = 0;

            if (x > 1.1)
                y = -x + 9;
            if (x < -1.1)
                y = Math.Pow(Math.Sin(3 * x), 2) / (Math.Pow(x, 4) + 1);

            Console.WriteLine("Для x = {0:f4}", x);
            Console.WriteLine("Результат = {0:f4}", y);
        }
    }
}