using System;
using System.Collections.Generic;

namespace Domain
{
    public class NumberLine
    {
        public NumberLine()
        {
            this.Unsorted = this.RandomList(50000, 100);
            this.Sorted = this.SortListGeneric(this.Unsorted);
        }

        public NumberLine(int numbers, int max)
        {
            this.Unsorted = this.RandomList(numbers, max);
            this.Sorted = this.SortListGeneric(this.Unsorted);
        }

        public NumberLine(ICollection<int> unsorted)
        {
            this.Unsorted = unsorted;
            this.Sorted = this.SortListGeneric(this.Unsorted);
        }

        public ICollection<int> Unsorted { get; }
        public ICollection<int> Sorted { get; }

        private ICollection<int> RandomList(int elements, int max)
        {
            Random rnd = new Random();
            List<int> nums = new List<int>();
            int counter = 0;

            while (counter++ < elements)
            {
                nums.Add(rnd.Next(1, max + 1));
            }

            return nums;
        }

        private ICollection<T> SortListGeneric<T>(ICollection<T> list)
        {
            List<T> sorted = new List<T>(list);
            int sortSize = list.Count;
            if (sortSize > 1)
            {
                // Console.WriteLine("time to sort list of length " + sortSize + "....");
                // DateTime finish;
                // DateTime start = DateTime.Now;
                sorted.Sort();

                // finish = DateTime.Now;
                // TimeSpan time = finish - start;
                // double timeToSort = time.TotalMilliseconds;
                // Console.WriteLine(time + " seconds to sort list");
            }

            return sorted;
        }
    }
}