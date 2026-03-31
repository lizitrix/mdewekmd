using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите порядок матрицы n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("matrix[" + i + "," + j + "] = ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j > n - 1)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\nМатрица после замены (ниже побочной диагонали = 0):");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nЭлементы выше побочной диагонали:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j < n - 1)
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
        }
        Console.WriteLine();
    }
}