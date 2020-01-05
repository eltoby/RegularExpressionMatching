namespace RegularExpressionMatching.Logic
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            var simplePattern = this.SimplifyPattern(p);

            var inputS = new Stack<char>(s);
            var patternS = new Stack<char>(simplePattern.ToArray());

            while (patternS.Count > 0)
            {
                if (patternS.Peek() == '*')
                    break;

                if (inputS.Count == 0)
                    return false;

                var expected = patternS.Pop();

                var actual = inputS.Pop();

                if (!this.Valid(actual, expected))
                    return false;
            }

            var pattern = patternS.ToList();
            pattern.Reverse();
            var remaining = inputS.ToList();
            remaining.Reverse();
            var input = new Queue<char>(remaining);

            while (pattern.Count > 0)
            {
                if (pattern.Count > 1)
                {
                    var next = pattern[1];

                    if (next == '*')
                        break;
                }

                if (input.Count == 0)
                    return false;

                var expected = pattern[0];

                var actual = input.Dequeue();
                pattern.RemoveAt(0);

                if (!this.Valid(actual, expected))
                    return false;
            }

            return this.IsMatch(input, new Queue<char>(pattern));
        }

        public bool IsMatch(Queue<char> input, Queue<char> pattern)
        {

            var lastMultipleDequeued = '0';

            while (pattern.Count > 0)
            {
                var expected = pattern.Dequeue();
                var next = '0';

                if (pattern.Count > 0)
                {
                    next = pattern.Peek();

                    if (next == '*')
                        pattern.Dequeue();
                }

                if (next == '*')
                {
                    if (expected == '.')
                    {
                        if (pattern.Count == 0)
                            return true;

                        var until = pattern.Peek();

                        while (input.Count > 0 && !this.Valid(input.Peek(), until))
                            lastMultipleDequeued = input.Dequeue();
                    }
                    else
                    {
                        while (input.Count > 0 && this.Valid(input.Peek(), expected))
                            lastMultipleDequeued = input.Dequeue();
                    }
                }
                else
                {
                    if (input.Count == 0)
                        return expected == lastMultipleDequeued;

                    if (!this.Valid(input.Dequeue(), expected))
                        return false;
                }
            }

            if (input.Count > 0)
                return this.Valid(input.Dequeue(), lastMultipleDequeued);

            return true;
        }

        public Queue<char> SimplifyPattern(string p)
        {
            var result = new Queue<char>();
            var simplified = false;

            for (var i = 0; i < p.Length; i++)
            {
                var n = p[i];

                if (p.Length - 1 == i)
                {
                    result.Enqueue(n);
                    break;
                }

                var n1 = p[i + 1];

                if (p.Length - 2 == i)
                {
                    result.Enqueue(n);
                    result.Enqueue(n1);
                    break;
                }

                if (n1 != '*')
                {
                    result.Enqueue(n);
                    continue;
                }

                var n2 = p[i + 2];

                if (n == n2)
                {
                    if ((p.Length - 3 == i || p[i + 3] != '*'))
                    {
                        result.Enqueue(n);
                        result.Enqueue(n2);
                        result.Enqueue(n1);
                        simplified = true;
                        i += 2;
                        continue;
                    }
                    else
                    {
                        result.Enqueue(n);
                        result.Enqueue(n1);
                        i += 3;
                        simplified = true;
                        continue;
                    }
                }
                else if ((n == '.' || n2 == '.') && i + 3 < p.Length && p[i + 3] == '*')
                {
                    result.Enqueue('.');
                    result.Enqueue('*');
                    i += 3;
                    simplified = true;
                    continue;
                }
                else
                {
                    result.Enqueue(n);
                    result.Enqueue(n1);
                    i ++;
                    continue;
                }
            }

            if (simplified)
            {
                var resultString = "";

                while (result.Count > 0)
                    resultString += result.Dequeue();

                return this.SimplifyPattern(resultString);
            }
            else
                return result;
        }

        private bool Valid(char actual, char expected)
        {
            if (expected == '.')
                return true;

            return expected == actual;
        }
    }
}
