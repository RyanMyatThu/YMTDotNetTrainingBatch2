using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMTDotNetTrainingBatch2.ConsoleApp
{
    internal class LINQPractice
    {
        public int[] Filter(int[] input, int n)
        {
            int[] filtered = input.Where(x => x != n).ToArray();
            return filtered;
        }

        public int[] AddAll(int[] input, int n)
        {
            int[] addedArr = input.Select(x => x + n).ToArray();
            return addedArr;
        }

        public int[] sortAsc(int[] input)
        {
            int[] sorted = input.OrderBy(x => x).ToArray();
            return sorted;
        }

        public int[] sortDesc(int[] input)
        {
            int[] sorted = input.OrderByDescending(x => x).ToArray();
            return sorted;
        }

        public int getFirst(int[] input)
        {
            return input.First();
        }

        public int getFirstOrDefault(int[] input)
        {
            return input.FirstOrDefault();
        }

        public int getMax(int[] input)
        {
            return input.Max();
        }
        public int getMin(int[] input)
        {
            return input.Min();
        }

        public double getAvg(int[] input)
        {
            return input.Average();
        }

        public int getCount(int[] input)
        {
            return input.Count();
        }

        public int getSum(int[] input)
        {
            return input.Sum();
        }
    }
}
