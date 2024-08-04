using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        Stack<char> charPairs = new Stack<char>();

        // We loop through the input, then push brackets/braces/parentheses onto the stack and whenever a pair exists, it's removed from the stack.
        bool wrongOrder = false;
        foreach (char ch in input)
        {
            char previous;
            switch (ch)
            {
                case '[' or '{' or '(':
                    charPairs.Push(ch);
                    break;
                case ']':
                    wrongOrder = !charPairs.TryPop(out previous) || (previous != '[');
                    break;
                case '}':
                    wrongOrder = !charPairs.TryPop(out previous) || (previous != '{');
                    break;
                case ')':
                    wrongOrder = !charPairs.TryPop(out previous) || (previous != '(');
                    break;
            };

            if (wrongOrder)
            {
                break;
            }
        }

        return !wrongOrder && charPairs.Count == 0;
    }
}
