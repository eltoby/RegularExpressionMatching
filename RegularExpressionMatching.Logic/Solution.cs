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

                if (expected == '*')
                {
                    expected = pattern.Pop();

                    var repeated = expected;

                    while (repeated == expected && input.Count > 0)
                        repeated = input.Pop();

                    if (input.Count == 0)
                        continue;
                    else if (repeated != '0')
                        input.Push(repeated);
                }

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
