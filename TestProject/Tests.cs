using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubstringSearchAlgorithms;
using SubstringSearchAlgorithms.Class;

namespace TestProject
{
    [TestClass]
    public class Tests
    {
        public ISustringSearcher[] GetSearchers()
        {
            var searchers = new ISustringSearcher[]
            {
                new RabinKarp(),
                new Brutforce(),
                new BoyerMoor(),
                new KnutMorisPrat()
            };
            return searchers;
        }


        [TestMethod]
        public void Test_aaaaaaaa_a()
        {
            var searchers = GetSearchers();
            var str = "aaaaaaaaaaaaaaaaaaaaa";
            var substring = "a";
            var expected = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
            foreach (var searcher in searchers)
            {
                var indxs = searcher.IndexOf(str, 0, substring);
                var result = string.Join(",", indxs);
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Test_aaaaaaaa_aa()
        {
            var searchers = GetSearchers();
            var str = "aaaaaaaaaaaaaaaaaaaaa";
            var substring = "aa";
            var expected = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19";
            foreach (var searcher in searchers)
            {
                var indxs = searcher.IndexOf(str, 0, substring);
                var result = string.Join(",", indxs);
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Test_abcacacdacbaca_ca()
        {
            var searchers = GetSearchers();
            var str = "abcacacdacbaca";
            var substring = "ca";
            var expected = "2,4,12";
            foreach (var searcher in searchers)
            {
                var indxs = searcher.IndexOf(str, 0, substring);
                var result = string.Join(",", indxs);
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Test_kalambur_notContains()
        {
            var searchers = GetSearchers();
            var str = "по следам";
            var substring = "после";
            var expected = "";
            foreach (var searcher in searchers)
            {
                var indxs = searcher.IndexOf(str, 0, substring);
                var result = string.Join(",", indxs);
                Assert.AreEqual(expected, result);
            }
        }
    }
}
