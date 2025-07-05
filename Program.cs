using System.Security.Principal;

namespace MyApp
{
    public delegate void ShowLog(string message);

    class Program
    {
        static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Info: {message}");
            Console.ResetColor();
        }

        static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Info: {message}");
            Console.ResetColor();
        }
        static int Sum(int a, int b, ShowLog? log) => a + b;
        static void Main(string[] args)
        {
            // ShowLog log = Info;
            // log += Warning;

            // log?.Invoke("Application started");
            // Func<int, int, ShowLog, int> tinhtong;
            // tinhtong = Sum;
            // Console.WriteLine(tinhtong(10, 20, null));
            // Action<string> log;
            // log = Info;
            // log?.Invoke("an xinh gai");
            // Sum(10, 20, null);

            Action<string> thongbao;
            Func<int, int, int> tinhtong;
            tinhtong = (a, b) => a + b;
            Console.WriteLine(tinhtong(10, 20));
            thongbao = (a) => Console.WriteLine("xin chao " + a);
            thongbao?.Invoke("an xinh gai ");

            int[] a = { 1, 2, 3, 4, 5, 6 };
            var k1 = a.Where((x) =>
            {
                return x % 2 == 0;
            }
            );
            Console.WriteLine("Cac so chan trong mang la: ");
            foreach (var item in k1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
