using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.SampleObjects
{
    public class NodeEnumerator<T> : IEnumerator<T>
    {
        private NodeEnumerator<T> mParent;
        private NodeEnumerator<T> mChild;
        private IEnumerator<T> mEnumerator;
        private IEnumerable<T> mEnumerable;
        public T Current => mEnumerator.Current;
        object IEnumerator.Current => mEnumerator.Current;
        public void AddChild(NodeEnumerator<T> aChildNode)
        {
            aChildNode.mParent = this;
            mChild = aChildNode;
        }
        public IEnumerable<T> GetDescendants()
        {
            List<T> lDescendants = new List<T>();
            NodeEnumerator<T> lNode = this;

            while (lNode != null)
            {
                lDescendants.Add(lNode.Current);
                lNode = lNode.mChild;
            }
            return lDescendants;
        }
        public void AddTerminal(NodeEnumerator<T> aTerminalNode)
        {
            NodeEnumerator<T> lExTerminalNode = this;
            while (lExTerminalNode.mChild != null)
            {
                lExTerminalNode = lExTerminalNode.mChild;
            }
            lExTerminalNode.mChild = aTerminalNode;
            aTerminalNode.mParent = lExTerminalNode;
        }
        public NodeEnumerator(IEnumerable<T> aEnumerable)
        {
            mEnumerable = aEnumerable;
            Reset();
        }
        public void Init()
        {
            NodeEnumerator<T> lNode = mChild;
            do
            {
                lNode.MoveNext();
                lNode = lNode.mChild;
            }
            while (lNode != null);
        }
        public bool MoveNext()
        {
            var lHasNext = mEnumerator.MoveNext();
            if (!lHasNext)
            {
                if (mChild != null)
                {
                    if (mChild.MoveNext())
                    {
                        Reset();
                        lHasNext = mEnumerator.MoveNext();
                    }
                }
            }
            return lHasNext;
        }
        public void Reset()
        {
            mEnumerator = mEnumerable.GetEnumerator();
        }
        public void Dispose()
        {
            mEnumerator.Dispose();
            if (mChild != null)
            {
                mChild.Dispose();
            }
            mParent = null;
            mChild = null;
        }
    }
}
