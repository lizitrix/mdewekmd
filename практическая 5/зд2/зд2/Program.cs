using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер матрицы n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

        int[,] matrix = new int[n, n];

   
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
             
                matrix[i, j] = Math.Abs(i - j) + 1;
            }
        }

        Console.WriteLine("\nСформированная матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }
    }
}