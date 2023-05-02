using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.SampleObjects
{
    public static class EnumerableHelper
    {
        public static IEnumerable<int> GetRandomEnumerableNegative(int aMin, int aCount)
        {
            Random lRandom = new Random();
            for (int i = 0; i < aCount; i++)
            { yield return lRandom.Next(aMin, -1); }
        }
        public static IEnumerable<int> GetRandomEnumerableBetween(int aMin, int aMax, int aCount)
        {
            Random lRandom = new Random();
            for (int i = 0; i < aCount; i++)
            { yield return lRandom.Next(aMin, aMax); }
        }
        public static IEnumerable<int> GetRandomEnumerableBetween(int aMin, int aMax, int aCount, int aSeedNumber)
        {
            Random lRandom = new Random(aSeedNumber);
            for (int i = 0; i < aCount; i++)
            { yield return lRandom.Next(aMin, aMax); }
        }
        public static IEnumerable<T> GetRangeEnumerable<T>(T aStart, T aEnd, T aIncrement,
            Func<T, T, T> aAdding)
            where T : unmanaged, IComparable<T>
        { return GetRangeEnumerable(aStart, aEnd, aIncrement, (x, y) => (x.CompareTo(y) < 0), aAdding); }
        public static IEnumerable<T> GetRangeEnumerable<T>(T aStart, T aEnd, T aIncrement,
            Func<T, T, bool> aComparing, Func<T, T, T> aAdding)
            where T : unmanaged
        {
            for (T i = aStart; aComparing(i, aEnd); i = aAdding(i, aIncrement))
            { yield return i; }
        }
    }
}
