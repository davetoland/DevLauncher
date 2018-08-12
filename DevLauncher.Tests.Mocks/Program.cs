using System;
using System.Threading;

namespace DevLauncher.Tests.MockConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("I am finished!");
        }
    }
}
