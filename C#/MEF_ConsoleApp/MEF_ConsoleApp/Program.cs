namespace MEF_ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new TestMEF();
            p.Start();
            Console.WriteLine(nameof(Main) + "  " + "Enter Command:");
            while (true)
            {
                string s = Console.ReadLine();
                Console.WriteLine("Output-" + p.calculator.Calculate(s));
            }
        }
    }
}