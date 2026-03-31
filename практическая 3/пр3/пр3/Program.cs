using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите e: ");
        double e = Convert.ToDouble(Console.ReadLine());

        double sum = 0;
        double factorial = 1;
        int n = 1;

        while (true)
        {
            double a = Math.Pow(10, n) / factorial;

            if (Math.Abs(a) < e)
                break;

            sum += a;
            n++;
            factorial *= n;
        }

        Console.WriteLine("Сумма = " + sum);
    }
}