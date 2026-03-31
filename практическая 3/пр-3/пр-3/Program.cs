using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите n : ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите k: ");
        int k = Convert.ToInt32(Console.ReadLine());

        int start = 1;
        int end = 9;

        if (n == 2) { start = 10; end = 99; }
        else if (n == 3) { start = 100; end = 999; }
        else if (n == 4) { start = 1000; end = 9999; }

        long sum = 0;

        for (int i = start; i <= end; i++)
        {
            if (i % k == 0)
            {
                sum += i;
            }
        }

        Console.WriteLine("Сумма = " + sum);
    }
}