using System;
using System.Collections.Generic;
using System.Linq;

namespace EightLamps
{
    class Program
    {
        static void Main(string[] args)
        {
            var lamps1 = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            var days1 = 50;
            var lamps2 = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
            var days2 = 50;

            Console.WriteLine("With imput " + String.Join(",", lamps1));
            Console.WriteLine("Result " + String.Join(",", LampsAfterXDays(lamps1, days1)));
            Console.WriteLine("With imput " + String.Join(",", lamps2));
            Console.WriteLine("Result " + String.Join(",", LampsAfterXDays(lamps2, days2)));
        }

        private static int[] LampsAfterXDays(int[] lamps, int days)
        {
            var casheOfOldResults = new List<int[]>();
            casheOfOldResults.Add(lamps);

            while (days > 0)
            {
                var temp = new int[8];

                for (int i = 0; i <= 7; i++)
                {
                    if (i == 0)
                    {
                        temp[i] = (0 == lamps[i + 1] ? 0 : 1);
                    }
                    else if (i < 7)
                    {
                        temp[i] = (lamps[i - 1] == lamps[i + 1] ? 0 : 1);
                    }
                    else 
                    {
                        temp[i] = (lamps[i - 1] == 0 ? 0 : 1);
                    }
                }

                days--;

                if (Enumerable.SequenceEqual(casheOfOldResults.First(), temp))
                {
                    return casheOfOldResults[days % casheOfOldResults.Count];
                }
                else
                {
                    casheOfOldResults.Add(temp);
                }

                Console.WriteLine("With imput " + days + " days before end " + String.Join(",", temp));

                lamps = temp;
            }

            return lamps;
        }
    }
}
