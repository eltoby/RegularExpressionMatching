namespace RegularExpressionMatching.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RegularExpressionMatching.Logic;

    [TestClass]
    public class RegularExpressionMatchingTests
    {
        [DataTestMethod]
        [DataRow("aa","a", false)]
        [DataRow("aa", "a*", true)]
        public void Examples(string s, string p, bool expected)
        {
            var sut = new Solution();
            var result = sut.IsMatch(s, p);
            Assert.AreEqual(expected, result);
        }
    }
}
