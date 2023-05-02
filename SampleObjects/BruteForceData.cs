using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.SampleObjects
{
    public class BruteForceData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                BruteForceTree<int> lTree = new BruteForceTree<int>(
                    new IEnumerable<int>[] {
                        EnumerableHelper.GetRandomEnumerableBetween(2, 20, 3, 2019281),
                        EnumerableHelper.GetRangeEnumerable(5, 8, 1, (x, y) => x + y),
                        EnumerableHelper.GetRangeEnumerable(-4, 0, 2, (x, y) => x + y)
                    });
                return lTree.GetValues();
            }
        }
    }
}
