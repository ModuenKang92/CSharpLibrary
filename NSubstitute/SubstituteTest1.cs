using CSharpLibrary.NUnit;
using CSharpLibrary.SampleObjects;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.Extensions;
using System.Collections;

namespace CSharpLibrary.NSubstitute
{
    [TestFixtureSource(typeof(BruteForceData), nameof(BruteForceData.FixtureParams))]
    public class SubstituteTest1
    {
        #region INITs
        private readonly IEnumerable mValues;
        private IInt3Processor processor;
        private int mResult;
        #endregion
        public SubstituteTest1(object aValues)
        {
            mValues = (IEnumerable)aValues;
        }
        #region SETUPs
        [SetUp]
        public void SetUp()
        {
            processor = Substitute.For<IInt3Processor>();
            processor
                .When((n) => n.Execute())
                .Do((args) =>
                {
                    int[] vals = new int[3];
                    int i = 0;
                    foreach (var val in mValues)
                    {
                        vals[i] = (int)val;
                        i++;
                    }
                    processor.Proceed(vals[0], vals[1], vals[2]);
                });
            processor
                .When((n) => n.Proceed(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()))
                .Do((args) =>
                {
                    mResult = (int)args[0] + (int)args[1] + (int)args[2];
                });
        }
        #endregion
        #region TESTs
        [Test]
        public void Test1()
        {
            processor.Execute();
            MyAssert.EqualTo(mResult, 5);
        }
        #endregion
    }
}
