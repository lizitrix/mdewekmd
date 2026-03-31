using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размеры отверстия A и B:");
            double A = Convert.ToDouble(Console.ReadLine());
            double B = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите размеры кирпича x, y, z:");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            double z = Convert.ToDouble(Console.ReadLine());

            if (x <= A && y <= B || x <= B && y <= A)
            {
                Console.WriteLine("Кирпич ПРОЙДЕТ");
            }
            else if (x <= A && z <= B || x <= B && z <= A)
            {
                Console.WriteLine("Кирпич ПРОЙДЕТ");
            }
            else if (y <= A && z <= B || y <= B && z <= A)
            {
                Console.WriteLine("Кирпич ПРОЙДЕТ");
            }
            else
            {
                Console.WriteLine("Кирпич НЕ ПРОЙДЕТ");
            }
        }
    }
}
