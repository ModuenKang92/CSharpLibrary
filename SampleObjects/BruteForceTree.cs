using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.SampleObjects
{
    public class BruteForceTree<T>
    {
        NodeEnumerator<T> mRoot;
        public BruteForceTree(IEnumerable<T>[] values)
        {
            foreach (var value in values)
            {
                if (mRoot == null)
                { mRoot = new NodeEnumerator<T>(value); }
                else
                { mRoot.AddTerminal(new NodeEnumerator<T>(value)); }
            }
        }
        public IEnumerable<IEnumerable<T>> GetValues()
        {
            mRoot.Init();
            Console.WriteLine();
            while (mRoot.MoveNext())
            { yield return mRoot.GetDescendants(); }
        }
    }
}
