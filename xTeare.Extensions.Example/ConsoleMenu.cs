using System;

namespace xTeare.Extensions.Example
{
    public static class ConsoleMenu
    {
        public static void SelectionMenu()
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

        public static void WaitAndClearConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(":: Press SPACE to return");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
            Console.Clear();
        }

        public static int EnterNumber(int Min = 1, int Max = int.MaxValue, bool clear = true, string extraText = "")
        {
            Console.WriteLine($":: Please enter an interger between {Min} and {Max}");

            if (extraText != "")
                Console.Write(":: " + extraText);

            string str = Console.ReadLine();
            Console.CursorTop--;
            Console.CursorLeft = str.Length + 3 + extraText.Length;

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
    }
}
