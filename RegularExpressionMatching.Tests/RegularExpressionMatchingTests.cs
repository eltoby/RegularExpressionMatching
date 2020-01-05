namespace RegularExpressionMatching.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RegularExpressionMatching.Logic;

    [TestClass]
    public class RegularExpressionMatchingTests
    {
        [DataTestMethod]
        [DataRow("aa", "a", false)]
        [DataRow("aa", "a*", true)]
        [DataRow("ab", ".*", true)]
        [DataRow("aab", "c*a*b", true)]
        [DataRow("mississippi", "mis*is*p*.", false)]
        [DataRow("mississippi", "mis*is*ip*.", true)]
        [DataRow("aaa", "ab*ac*a", true)]
        [DataRow("aaa", "ab*a*c*a", true)]
        [DataRow("ab", ".*c", false)]
        [DataRow("bbbba", ".*a*a", true)]
        [DataRow("ab", ".*..", true)]
        [DataRow("abbbcd", "ab*bbbcd", true)]
        [DataRow("abcdede", "ab.*de", true)]
        [DataRow("aaaa", "aaa", false)]
        [DataRow("aaa", "aaaa", false)]
        [DataRow("a", ".*..a", false)]
        [DataRow("", ".*", true)]
        [DataRow("aaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*a*a*a*b", true)]
        [DataRow("aabcbcbcaccbcaabc", ".*a*aa*.*b*.c*.*a*", true)]
        [DataRow("baabbbaccbccacacc", "c*..b*a*a.*a..*c", true)]
        [DataRow("cbaacacaaccbaabcb","c*b*b*.*ac*.*bc*a*", true)]
        public void Examples(string s, string p, bool expected)
        {
            var sut = new Solution();
            var result = sut.IsMatch(s, p);
            Assert.AreEqual(expected, result);
        }
        
        [DataTestMethod]
        [DataRow("ab*bbbcd", "abbbb*cd")]
        [DataRow("a*a*a*a*a*a*a*a*a*a*a*a*b", "a*b")]
        [DataRow(".*a*", ".*")]
        [DataRow(".*c", ".*c")]
        [DataRow("a*a", "aa*")]
        [DataRow("c*b*b*.*ac*.*bc*a*", ".*a.*bc*a*")]
        public void Simplify(string p, string expected)
        {
            var sut = new Solution();
            var result = sut.SimplifyPattern(p);
            var resultString = "";

            while (result.Count > 0)
                resultString += result.Dequeue();

            Assert.AreEqual(expected, resultString);
        }
    }
}
