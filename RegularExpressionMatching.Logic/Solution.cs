namespace RegularExpressionMatching.Logic
{
    using System.Collections.Generic;

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            var pattern = this.SimplifyPattern(new Queue<char>(p));
            var input = new Queue<char>(s);

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

                        if (pattern.Count > 1 && pattern.ToArray()[1] == '*')
                        {
                            pattern.Dequeue();
                            until = pattern.Dequeue();
                        }

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

        public Queue<char> SimplifyPattern(Queue<char> p)
        {
            var result = new Queue<char>(p.Count);
            var initial = new Queue<char>(p);

            var simplified = false;
            while (initial.Count > 0)
            {
                var current = initial.Dequeue();

                if (initial.Count == 0)
                {
                    result.Enqueue(current);
                    break;
                }

                var next = initial.Peek();
                result.Enqueue(current);

                if (next == '*')
                {
                    initial.Dequeue();

                    if (initial.Count > 0 && initial.Peek() == current)
                    {
                        result.Enqueue(initial.Dequeue());
                        simplified = true;
                    }

                    result.Enqueue(next);
                }
            }

                if (simplified)
                    return this.SimplifyPattern(result);
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
