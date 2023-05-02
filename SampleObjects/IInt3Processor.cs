using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.SampleObjects
{
    public interface IInt3Processor
    {
        void Execute();
        void Proceed(int a, int b, int c);
    }
}
