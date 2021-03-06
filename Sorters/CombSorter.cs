namespace SortingAlgos.Sorters
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Comb sorter.  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CombSorter<T> : Sorter<T>
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer to use in comparing items.</param>
        public override void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (null == list) throw new ArgumentNullException("list");
            if (null == comparer) throw new ArgumentNullException("comparer");
            if (1 >= list.Count) return;

            var beg = 0;
            var end = list.Count - 1;

            Sort(list, beg, end, comparer);
        }

        public static void Sort(IList<T> list, int beg, int end, IComparer<T> comparer)
        {
            if (beg < 0) beg = 0;
            if (end >= list.Count) end = list.Count - 1;
            if (beg > end) beg = end;

            var pass = 0;
            var swap = 0;

            var gap = end - beg + 1;
            var swapped = false;
            while (gap > 1 || swapped)
            {
                if (gap > 1)
                {
                    gap = (int) (gap / 1.3); //1.247330950103979);
                    if (gap < 1) gap = 1;
                    if (gap == 9 || gap == 10) gap = 11;
                }
                swapped = false;
                var curr = beg;
                while (curr + gap <= end)
                {
                    var next = curr + gap;
                    if (comparer.Compare(list[curr], list[next]) > 0)
                    {
                        Swap(list, curr, next);
                        swapped = true;
                        ++swap;
                    }
                    curr = next;
                    ++pass;
                }
            }

            Console.WriteLine("pass :" + pass);
            Console.WriteLine("swap :" + swap);
        }
    }
}
