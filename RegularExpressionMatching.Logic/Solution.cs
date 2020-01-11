namespace RegularExpressionMatching.Logic
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(p))
                return string.IsNullOrEmpty(s);

            var firstMatch = !string.IsNullOrEmpty(s) && (s[0] == p[0] || p[0] == '.');

            if (p.Length >= 2 && p[1] == '*')
                return this.IsMatch(s, p.Substring(2)) || (firstMatch && this.IsMatch(s.Substring(1), p));
            else
                return firstMatch && this.IsMatch(s.Substring(1), p.Substring(1));

        }
    }
}
