using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[N];

        Console.WriteLine("Введите " + N + " целых чисел:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("arr[" + i + "] = ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = 0;
        for (int i = 0; i < N; i++)
        {
            if (arr[i] == i + 1)
            {
                sum += arr[i];
            }
        }

        Console.WriteLine("Сумма элементов = " + sum);
    }
}7