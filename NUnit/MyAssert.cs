using NUnit.Framework;

namespace CSharpLibrary.NUnit
{
    public static class MyAssert
    {
        public static void EqualTo<T>(T actual, T expected)
        { Assert.That(actual, Is.EqualTo(expected)); }
    }
}
