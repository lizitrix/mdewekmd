using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите начало отрезка a (>0): ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите конец отрезка b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите шаг h: ");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n----------------------");
        Console.WriteLine("   x    |    F(x)    ");
        Console.WriteLine("----------------------");

        for (double x = a; x <= b + h / 2; x += h)
        {
            double F = 2 * Math.Cos(Math.Sqrt(x)) + 0.5 / x;
            Console.WriteLine("{0,7:f4} | {1,10:f4}", x, F);
        }

        Console.WriteLine("----------------------");
    }
}