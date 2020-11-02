using System;
using System.Collections.Generic;
using System.Linq;
using xTeare.Extensions.Utils;

namespace xTeare.Extensions.Example
{
    public static class MiscExamples
    {
        public static void RandomWeightExample()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;


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
                new WeightedKeyPairValue("emerald",     0, 2, 0),
                new WeightedKeyPairValue("diamond",     0, 1, 0)
            };

            foreach (WeightedKeyPairValue wkvp in Pairs)
            {
                string key = wkvp.Key;
                int longestLength = Pairs.Max(e => ((string)e.Key).Length);
                if (key.Length < longestLength )
                    for (int i = key.Length; i < longestLength ; i++)
                        key += " ";

                string tabs = (((string)wkvp.Key).Length > 5) ? "\t" : "\t\t";
                string numUnderTen = (wkvp.InitialWeight < 10) ? " " : "";
                Console.WriteLine($":: Entry {key}  has a weighting of {numUnderTen}{wkvp.InitialWeight}");
            }


            Console.WriteLine();

            int iterations = ConsoleMenu.EnterNumber(1, 1000000, false, "Select ");
            Console.Write(" random ores.\n");

            Console.WriteLine();
            List<string> selection = new List<string>();

            for (int i = 0; i < iterations; i++)
            {
                WeightedKeyPairValue wkvp = Pairs.RandomElementByWeight();
                selection.Add(wkvp.Key);

            }

            foreach (WeightedKeyPairValue kvp in Pairs)
            {
                int cnt = selection.Count(e => e.Contains(kvp.Key));

                float percent = (float)cnt / (float)iterations;
                Console.WriteLine($":: {kvp.Key} \twas selected {cnt} times.\t ({percent.ToString("P")})");
            }
        }
    }
}
