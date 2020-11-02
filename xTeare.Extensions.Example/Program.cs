using System;
using System.Collections.Generic;
using System.Linq;
using xTeare.Extensions.BaseTypes;
using xTeare.Extensions.Utils;

namespace xTeare.Extensions.Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            
            while (!exit)
            {
                ConsoleMenu.SelectionMenu();
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;

                    case ConsoleKey.W:
                        MiscExamples.RandomWeightExample();
                        ConsoleMenu.WaitAndClearConsole();
                        break;

                    case ConsoleKey.B:
                        StringExamples.BetweenExample();
                        ConsoleMenu.WaitAndClearConsole();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
