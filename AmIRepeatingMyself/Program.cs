using System;

namespace AmIRepeatingMyself
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide a sentence as the first command line argument.");
                Console.WriteLine("For example:");
                Console.WriteLine("     AmIRepeatingMyself \"Hello world!\"");
            }
            else
            {
                var counter = new WordCounter();
                var statistics = counter.CountWordOccurances(args[0]);
                foreach (var line in statistics)
                {
                    Console.WriteLine($"{line.Occurances:d3} - {line.Word}");
                }
            }
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
