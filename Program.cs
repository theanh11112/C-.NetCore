using System;
// using System.Net.NetworkInformation;
using MyFirstApp;
namespace MyFirstApp
{
    static class Program
    {

        //     extension method 

        // public static void Print1(this string s, ConsoleColor color)
        // {
        //     Console.ForegroundColor = color;
        //     Console.WriteLine(s);
        //     Console.ResetColor();
        // }
        static void Main(string[] args)
        {
            int[] a = [1, 2, 3, 4, 5, 2];
            int max = a.Max();
            Console.WriteLine("The maximum value in the array is: " + max);
            // Print("Hello, World!", ConsoleColor.Green);
            // Print("An xinh gai", ConsoleColor.Red);
            // "An xinh gai".Print(ConsoleColor.Blue);
            "An xinh gai".Print(ConsoleColor.Green);
            double number = 4.0;
            Console.WriteLine($"The square of {number} is: {number.Binhphuong()}");
            Console.WriteLine($"The square root of {number} is: {number.Canbac2()}");
            Console.WriteLine($"The sine of {number} is: {number.Sin()}");
            Console.WriteLine($"The cosine of {number} is: {number.Cos()}");
        }
    }
    // Tai lieu : Phuong thuc mo rong (Extension Methods) trong C# : mo rong mot lop co san ma khong can phai tao ra 1 doi tuong ke thua tu lop truoc 
    // Muon tao ra phuong thuc mo rong cho mot lop, ta can khai bao mot lop static va mot phuong thuc static voi tu khoa "this" truoc tham so dau tien cua phuong thuc
    // Phuong thuc mo rong cho phep ta goi phuong thuc nhu
    // the string s = "Hello, World!";
    // s.Print(ConsoleColor.Green);
    // Trong do, "Print" la phuong thuc mo rong cua lop string,
    // cho phep ta in ra chuoi voi mau sac da chon. Phuong thuc mo rong cung co the duoc su dung voi cac lop khac, mien la lop string hoac cac lop ke thua tu lop string.
    // Phuong thuc mo rong cung co the duoc su dung voi cac lop khac, mien la lop string hoac cac lop ke thua tu lop string.


}
