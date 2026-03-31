using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("введите высоту");
            double H = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите радиус основания");
            double r = Convert.ToDouble(Console.ReadLine());

            double Vcone = 1.0 / 3.0 * Math.PI * Math.Pow(r, 2) * H;
            double Vcyl = Math.PI * Math.Pow(r, 2) * H;

            Console.WriteLine("для H={0:f4} и r={1:f4}", H, r);
            Console.WriteLine("конус ={0:f4} и цилиндр ={0:f4}", Vcone, Vcyl);
        }
    }
}

