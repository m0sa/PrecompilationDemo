using System;
using System.Text;

namespace PrecompilationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            Console.WriteLine("Who are you?");
            var who = Console.ReadLine();
            who = string.IsNullOrWhiteSpace(who) ? "stranger" : who;
            sb.Append($"Hello {who}");
            Console.WriteLine(sb.ToString());
        }
    }
}
