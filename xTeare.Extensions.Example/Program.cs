using System;
using System.Collections.Generic;
using System.Linq;
using xTeare.Extensions.BaseTypes;
using xTeare.Extensions.Utils;

namespace xTeare.Extensions.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dontExit = true;

            while (dontExit)
            {
                SelectionMenu();
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        dontExit = false;
                        break;

                    case ConsoleKey.W:
                        RandomWeightExample();
                        WaitAndClearConsole();
                        break;

                    case ConsoleKey.B:
                        BetweenExample();
                        WaitAndClearConsole();
                        break;
                }

            }
        }

        private static int EnterNumber(int Min = 1, int Max = int.MaxValue, bool clear = true, string extraText = "")
        {
            Console.WriteLine($":: Please enter an interger between {Min} and {Max}");
            if (extraText != "")
                Console.Write(":: " + extraText);
            string str = Console.ReadLine();

            if (!int.TryParse(str, out int result))
            {
                
                Console.WriteLine(":: Please check your input.");
                if (clear)
                    Console.Clear();
                return Min;
            }
            if (clear)
                Console.Clear();
            return result;
        }

        private static void SelectionMenu()
        {
            Console.WriteLine(":: Enter shown key to run example");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(":: WeightedRandom example \tW");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(":: Between example \t\tB");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(":: Exit \t\t\tESC");
        }

        private static void BetweenExample()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string original = "The quick brown fox jumps over the lazy dog";
            Console.WriteLine($":: Search for any word(s) in this string '{original}'");

            Console.Write(":: Enter first string : ");
            string a = Console.ReadLine();

            Console.Write(":: Enter second string : ");
            string b = Console.ReadLine();


            Console.Write(":: Remove WhiteSpaces [y/n] : ");
            bool removeWhiteSpace = Console.ReadKey().Key == ConsoleKey.Y;

            Console.Write("\n");
            Console.Write(":: Ignore Case [y/n] : ");
            bool ignoreCase = Console.ReadKey().Key == ConsoleKey.Y;

            Console.WriteLine();
            Console.WriteLine($":: Between Example results");
            Console.WriteLine();
            Console.WriteLine($":: Recieve string between '{a}' and '{b}'");
            Console.WriteLine($":: in '{original}'");
            Console.WriteLine($":: Found string : '{original.Between(a, b, removeWhiteSpace, ignoreCase)}'");

        }

        private static void WaitAndClearConsole()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press SPACE to return");
            while(Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
            }
            Console.Clear();
        }

        private static void RandomWeightExample()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int iterations = EnterNumber(1, 1000000, false, "Amount of runs : ");
            List<WeightedKeyPairValue> Pairs = new List<WeightedKeyPairValue>()
            {
                new WeightedKeyPairValue("stone",       0, 13, 0),
                new WeightedKeyPairValue("quartz",      0, 12, 0),
                new WeightedKeyPairValue("coal",        0, 11, 0),
                new WeightedKeyPairValue("iron",        0, 10, 0),
                new WeightedKeyPairValue("tungsten",    0, 9, 0),
                new WeightedKeyPairValue("Silver",      0, 8, 0),
                new WeightedKeyPairValue("gold",        0, 7, 0),
                new WeightedKeyPairValue("platin",      0, 6, 0),
                new WeightedKeyPairValue("topaz",       0, 5, 0),
                new WeightedKeyPairValue("rubin",       0, 4, 0),
                new WeightedKeyPairValue("sapphire",    0, 3, 0),
                new WeightedKeyPairValue("emerald",      0, 2, 0),
                new WeightedKeyPairValue("diamond",     0, 1, 0)
            };

            int repeats = iterations;
            Console.WriteLine($":: Selecting {repeats} random ores");

            List<string> selection = new List<string>();

            for (int i = 0; i < repeats; i++)
            {
                WeightedKeyPairValue wkvp = Pairs.RandomElementByWeight();
                selection.Add(wkvp.Key);

            }

            foreach (WeightedKeyPairValue kvp in Pairs)
            {
                int cnt = selection.Count(e => e.Contains(kvp.Key));

                float percent = (float)cnt / (float)repeats;
                Console.WriteLine($":: {kvp.Key} \twas selected {cnt} times.\t ({percent.ToString("P")})");
            }
        }
    }
}
