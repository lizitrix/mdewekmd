using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите начало отрезка a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите конец отрезка b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите шаг h: ");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n----------------------");
        Console.WriteLine("    x    |    F(x)    ");
        Console.WriteLine("----------------------");

        for (double x = a; x <= b; x += h)
        {
            double F = 3 * Math.Sqrt(x) + Math.Tan(1 / x);
            Console.WriteLine("{0,8:f4} | {1,10:f4}", x, F);
        }

        Console.WriteLine("----------------------");
    }
}