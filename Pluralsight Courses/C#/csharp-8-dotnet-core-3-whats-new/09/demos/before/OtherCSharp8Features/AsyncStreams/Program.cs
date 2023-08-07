using System;
using System.Threading;

namespace AsyncStreams
{
    class Program
    {
        static int ThreadId => Thread.CurrentThread.ManagedThreadId;

        static void Main(string[] args)
        {
            var orderFactory = new OrderFactory();

            Console.WriteLine($"[{ThreadId}]Enumerating orders...");

            foreach (var order in orderFactory.MakeOrders(5))
            {
                Console.WriteLine($"[{ThreadId}]Received order {order.Id}.");
            }

            Console.WriteLine($"[{ThreadId}]All orders created!");
        }
    }
}
