using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace MyApp
{
    public delegate void Sukiennhapso(int number);


    class SukiennhapsoEventArgs(int number) : EventArgs
    {
        public int Number { get; } = number;
    }
    public class UserInput
    {
        // public Sukiennhapso? Sukiennhapso { set; get; }
        public event EventHandler? Sukiennhapso;

        public void Input()
        {
            do
            {
                Console.WriteLine("Enter a number:");
                string? s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Input was null or empty.");
                    return;
                }
                int number = Int32.Parse(s);
                Sukiennhapso?.Invoke(this, new SukiennhapsoEventArgs(number));
            } while (true);
        }
    }

    class Tinhcan
    {
        public void Sub(UserInput userInput)
        {
            userInput.Sukiennhapso += Can;
        }
        public void Can(object? sender, EventArgs e)
        {
            SukiennhapsoEventArgs args = (SukiennhapsoEventArgs)e;
            int number = args.Number;
            Console.WriteLine($"Can bac 2 cua so : {number} la {Math.Sqrt(number)}  ");

        }

        class TinhBinhPhuong
        {
            public void Sub(UserInput userInput)
            {
                userInput.Sukiennhapso += BinhPhuong;
            }
            public void BinhPhuong(object? sender, EventArgs e)
            {
                SukiennhapsoEventArgs args = (SukiennhapsoEventArgs)e;
                int number = args.Number;
                Console.WriteLine($"Binh phuong cua so : {number} la {number * number}  ");
                Console.WriteLine($"Sender: {sender?.GetType().Name}, EventArgs: {e.GetType().Name}    ");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                UserInput userInput = new();
                userInput.Sukiennhapso += (sender, e) =>
                {
                    Console.WriteLine("an xinh gai ");
                };

                Tinhcan tinhcan = new();
                tinhcan.Sub(userInput);

                TinhBinhPhuong tinhbinhphuong = new();
                tinhbinhphuong.Sub(userInput);

                userInput.Input();
            }
        }
    }
}
