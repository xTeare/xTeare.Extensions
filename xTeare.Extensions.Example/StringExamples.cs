using System;
using xTeare.Extensions.BaseTypes;

namespace xTeare.Extensions.Example
{
    public static class StringExamples
    {

        public static void BetweenExample()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            string original = "The quick brown fox jumps over the lazy dog";
            Console.WriteLine($":: Search for any word(s) in this string '{original}'");

            Console.Write(":: Enter start string : ");
            string start = Console.ReadLine();

            Console.Write(":: Enter end string : ");
            string end = Console.ReadLine();


            Console.Write(":: Remove WhiteSpaces [y/n] : ");
            bool removeWhiteSpace = Console.ReadKey().Key == ConsoleKey.Y;

            Console.Write("\n");
            Console.Write(":: Ignore Case [y/n] : ");
            bool ignoreCase = Console.ReadKey().Key == ConsoleKey.Y;

            Console.WriteLine();
            Console.WriteLine($":: Between Example results");
            Console.WriteLine();
            Console.WriteLine($":: Trying to recieve string between '{start}' and '{end}'");
            Console.WriteLine($":: in '{original}'");
            Console.WriteLine($":: Found string : '{original.Between(start, end, removeWhiteSpace, ignoreCase)}'");

        }
    }
}
