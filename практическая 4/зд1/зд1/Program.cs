using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        string s1 = Console.ReadLine();

        Console.Write("Введите второе число: ");
        string s2 = Console.ReadLine();

        string result = AddBigNumbers(s1, s2);
        Console.WriteLine("Сумма = " + result);
    }

    static string AddBigNumbers(string a, string b)
    {
        if (a.Length < b.Length) return AddBigNumbers(b, a);

        int carry = 0;
        string result = "";
        int diff = a.Length - b.Length;

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int digitA = a[i] - '0';
            int digitB = (i - diff >= 0) ? b[i - diff] - '0' : 0;

            int sum = digitA + digitB + carry;
            result = (sum % 10) + result;
            carry = sum / 10;
        }

        if (carry > 0) result = carry + result;
        return result;
    }
}
