namespace RegularExpressionMatching.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RegularExpressionMatching.Logic;

    [TestClass]
    public class RegularExpressionMatchingTests
    {
        [DataTestMethod]
        //[DataRow("aa", "a", false)]
        //[DataRow("aa", "a*", true)]
        //[DataRow("ab", ".*", true)]
        //[DataRow("aab", "c*a*b", true)]
        //[DataRow("mississippi", "mis*is*p*.", false)]
        //[DataRow("mississippi", "mis*is*ip*.", true)]
        //[DataRow("aaa", "ab*ac*a", true)]
        //[DataRow("aaa", "ab*a*c*a", true)]
        //[DataRow("ab", ".*c", false)]
        //[DataRow("bbbba", ".*a*a", true)]
        //[DataRow("ab", ".*..", true)]
        [DataRow("abbbcd", "ab*bbbcd", true)]
        public void Examples(string s, string p, bool expected)
        {
            var sut = new Solution();
            var result = sut.IsMatch(s, p);
            Assert.AreEqual(expected, result);
        }
    }
}
