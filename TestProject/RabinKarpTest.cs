using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubstringSearchAlgorithms.Class;

namespace TestProject
{
    [TestClass]
    public class RabinKarpTest
    {
        [TestMethod]
        public void RabinKarp()
        {
            var rabinKarp = new RabinKarp();
            var str = "abcaabccaabcd";
            var subStr = "abc";

            var result = rabinKarp.IndexOf(str, 0,subStr);
            var expected = new int[] {0,4,9 };
            Assert.AreEqual(expected.Length, result.Length);

            for(var i = 0;i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void RabinKarp2()
        {
            var rabinKarp = new RabinKarp();
            var str = "aaaaaaaaaaa";
            var subStr = "aaa";

            var result = rabinKarp.IndexOf(str, 0, subStr);

            var count = str.Length - subStr.Length+1;
            Assert.AreEqual(count, result.Length);

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(i, result[i]);
            }
        }
    }
}
