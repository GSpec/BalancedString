using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedString
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();
        }

        static int Solution(string s)
        {
            for (var substringLength = 2; substringLength <= s.Length; substringLength++)
            {
                for (var i = 0; i <= s.Length - substringLength; i++)
                {
                    var currentSubstring = s.Substring(i, substringLength);
                    if (IsBalanced(currentSubstring))
                        return currentSubstring.Length;
                }
            }

            return -1;
        }

        static bool IsBalanced(string s)
        {
            if (s.Length < 2) return false;

            return s.All(
                c =>
                    (char.IsLower(c) && s.Contains(char.ToUpper(c))) ||
                    (char.IsUpper(c) && s.Contains(char.ToLower(c))));
        }

        static void RunTests()
        {
            var tests = new Dictionary<string, int>()
            {
                [""] = -1,
                ["aZ"] = -1,
                ["aA"] = 2,
                ["aAbB"] = 2,
                ["TacoCat"] = -1,
                ["azABaabza"] = 5,
                ["AcZCbaBz"] = 8,
                ["abcdefghijklmnopqrstuvwxyz"] = -1,
            };

            var success = true;
            foreach (var test in tests)
            {
                var testResult = Solution(test.Key);
                if (testResult == test.Value)
                {
                    Console.WriteLine($"Test '{test.Key}' Passed.");
                }
                else
                {
                    Console.WriteLine($"Test '{test.Key}' Failed. Expected {test.Value}, but actual was {testResult}.");
                    success = false;
                }
            }

            Console.WriteLine("====");
            if (success)
            {
                Console.WriteLine("All tests pass!");
            }
            else
            {
                Console.WriteLine("One or more tests failed");
            }
        }
    }
}
