using System;
using System.Threading.Tasks;

namespace TestSolution.Tasks.First
{
    class AsyncCafe
    {
        public async Task MakeBreakfast()
        {
            await Task.WhenAll(
                CutMushRoomsAsync(5),
                FryMushRoomAsync(),
                FryBreadSlicesAsync(2),
                FryEggsAsync(2)
            );
            Console.WriteLine("Breakfast is ready");
        }
        private async Task CutMushRoomsAsync(int amount) {
            Console.WriteLine($"Cutting {amount} mushrooms...");
            await Task.Delay(100);
            Console.WriteLine("Mushrooms were cutted");
        }

        private  async Task FryMushRoomAsync() { 
            Console.WriteLine("Frying mushrooms...");
            await Task.Delay(200);
            Console.WriteLine("Mushrooms were fried");
        }

        private async Task FryBreadSlicesAsync(int amount) {
            Console.WriteLine($"Frying {amount} bread slices...");
            await Task.Delay(200);
            Console.WriteLine("Bread slices were fried");
        }

        private async Task FryEggsAsync(int amount) {
            Console.WriteLine($"Frying {amount} eggs...");
            await Task.Delay(100);
            Console.WriteLine("Eggs were fried");
        }
    }
}
