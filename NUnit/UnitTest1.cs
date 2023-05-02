using CSharpLibrary.SampleObjects;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary.NUnit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MyCategoryNameAttribute : CategoryAttribute
    { }
    public class UnitTest1
    {
        int count1 = 0;
        int count2 = 0;
        [OneTimeSetUp]
        public void SetUp1()
        { count1++; }
        [SetUp]
        public void SetUp2()
        { count2++; }
        [Test]
        public void Test1()
        {
            //List<string> b = new List<string>();
            //Exception e = new Exception();
            //Assert.That(b, Has.Property("Capacity"));
            //Assert.That(a, Has.Length);
            //Assert.That(b, Has.Count);
            //Assert.That(e, Has.Message);
            //Assert.That(e, Has.InnerException);
            string[] arr = { "application", "apple", "maple" };
            Assert.That(arr, Has.Some.StartsWith("ap"));
            Assert.That(arr, Has.No.Exactly(1).EndsWith("ple"));
            Assert.That(arr, Has.None.Null);
            Assert.That(arr, Has.Member("apple"));
            Assert.That(arr, Has.ItemAt(1).StartsWith("ma"));


            //Assert.That(count1, Is.AtLeast(3));
        }
        [Test]
        public void Test2()
        {
            Assume.That(1, Is.EqualTo(3));
            //Warn.If(2 + 2 != 5);
            Assert.That(2, Is.AtLeast(3));
            //Assert.Inconclusive();
            //Assert.Multiple(() => {
            //    MyAssert.EqualTo(1, 2);
            //    MyAssert.EqualTo(4, 2);
            //    MyAssert.EqualTo(5, 2);
            //});
            //MyAssert.EqualTo(count1, 1);
            //MyAssert.EqualTo(count2, 2);
        }
        [Test]
        public void Test3()
        {
            MyAssert.EqualTo(count1, 1);
            Assert.That(count2, Is.EqualTo(5));
        }
        [Test, Combinatorial]
        public void MyTest(
            [Range(1, 6)] int x,
            //[Values("A", "B")] string s,
            [ValueSource(typeof(MyStringDataClass), nameof(MyStringDataClass.TestCases))] string s)
        {
            Assert.Greater(5, x);
            StringAssert.DoesNotContain("C", s);
        }
    }
    public class AssignableClass {
        public AssignableClass()
        {

        }
    }

    public class MyStringDataClass
    {
        public static IEnumerable TestCases
        {
            get  // 기대값들
            {
                yield return "A";
                yield return "B";
            }
        }
        public static string Name { get { return "modeun"; } }
    }


    [TestFixture(typeof(int))]
    [TestFixture(typeof(double))]
    public class TheorySampleTestsGeneric<T>
    {
        [Datapoint]
        public double[] ArrayDouble1 = { 1.2, 3.4 };
        [Datapoint]
        public double[] ArrayDouble2 = { 5.6, 7.8 };
        [Datapoint]
        public int[] ArrayInt = { 0, 1, 2, 3 };

        [Theory]
        public void TestGenericForArbitraryArray(T[] array)
        {
            Assert.That(array.Length, Is.LessThanOrEqualTo(4));
        }
    }
    [TestFixture]
    public class MyTests
    {
        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public int DivideTest1(int n, int d)
        {
            return n / d;
        }
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest2(int n, int d, int q)
        {
            Assert.That(n / d, Is.EqualTo(q));
        }
        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
    }
    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get  // 기대값들
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
}