using System;

namespace MyFirstApp
{
    // This is an extension method for the string class
    public static class StringExtensions
    {
        // This method allows you to print a string in a specified color
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }

    public static class ExtensionDuoble
    {
        public static double Binhphuong(this double a)
        {
            return a * a;
        }

        public static double Canbac2(this double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Cannot calculate square root of a negative number.");
            }
            return Math.Sqrt(a);
        }

        public static double Sin(this double a)
        {
            return Math.Sin(a);
        }

        public static double Cos(this double a)
        {
            return Math.Cos(a);
        }
    }
}