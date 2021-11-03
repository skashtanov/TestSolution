using System;
using System.Threading.Tasks;
using TestSolution.Tasks.First;

namespace TestSolution
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cafe = new AsyncCafe();
            await cafe.MakeBreakfast();
            Console.WriteLine("FFFFFF");
            Console.ReadKey();
        }
    }
}
