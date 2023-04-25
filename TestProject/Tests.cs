using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubstringSearchAlgorithms;
using SubstringSearchAlgorithms.Class;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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

        [TestMethod]
        public void SearchBagOfWordsOnAnnaTxt()
        {
            var algms = GetSearchers();
            string text;
            using (var sr = new StreamReader("anna.txt", Encoding.UTF8))
            {
                text = sr.ReadToEnd().ToLower();
            }

            int number = 100;
            Regex rg = new Regex(@"\w+");
            var bag = new HashSet<string>();
            var matches = rg.Matches(text);
            foreach (var match in matches)
            {
                bag.Add(match.ToString());
                if (bag.Count > number) break;
            }
            foreach (var pattern in bag)
            {
                var BF = algms[1];
                var expected = BF.IndexOf(text, 0, pattern);
                foreach (var algm in algms)
                {
                    var actual = algm.IndexOf(text, 0, pattern);
                    CollectionAssert.AreEqual(expected, actual);
                }
            }
        }

    }
}
