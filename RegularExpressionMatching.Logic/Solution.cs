namespace RegularExpressionMatching.Logic
{
    using System.Collections.Generic;

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            var pattern = new Stack<char>(p);
            var input = new Stack<char>(s);

            while (pattern.Count > 0)
            {
                var expected = pattern.Pop();

                if (input.Count == 0)
                    return false;

                var actual = input.Pop();

                if (expected != actual)
                    return false;
            }

            if (input.Count > 0)
                return false;

            return true;
        }
    }
}
