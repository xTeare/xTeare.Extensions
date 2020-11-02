using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xTeare.Extensions.Utils
{
    public static class Utils
    {
        public static WeightedKeyPairValue RandomElementByWeight(this IList<WeightedKeyPairValue> list)
        {
            if (list.Count < 1)
                return null;

            int sum = list.Sum(e => e.InitialWeight);
            int start = 0;
            int choice = list[0].Random.Next(sum);

            foreach (WeightedKeyPairValue wkvp in list)
            {
                for (int i = start; i < wkvp.InitialWeight + start; i++)
                    if (i >= choice)
                        return wkvp;

                start += wkvp.InitialWeight;
            }

            return null;
        }
    }

    public class WeightedKeyPairValue
    {
        public dynamic Key;
        public dynamic Value;
        public int InitialWeight;
        public int WeightIncrease;
        public int CurrentWeight { get; internal set; }

        private Random random;
        internal Random Random
        {
            get
            {
                if (random == null)
                    random = new Random();
                return random;
            }
        }

        public WeightedKeyPairValue(dynamic Key, dynamic Value, int InitialWeight, int WeightIncrease)
        {
            this.Key = Key;
            this.Value = Value;
            this.InitialWeight = InitialWeight;
            this.WeightIncrease = WeightIncrease;
        }
    }
}
