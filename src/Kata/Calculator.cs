using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var delimeters = GetDelimeters(ref s);
            var numbers = getNumbers(s, delimeters);
            return numbers.Sum();
        }

        private static string[] GetDelimeters(ref string s)
        {
            var delimeters = new[] {",", "\n"};
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                delimeters = parts[0].Replace("//", "").Replace("[", "").Split("]");
                s = parts[1];
            }

            return delimeters;
        }

        private static IEnumerable<int> getNumbers(string s, string[] delimeters)
        {
            var numbers = s.Split(delimeters, StringSplitOptions.None).Select(int.Parse).Where(n => n < 1001);
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Count() > 0)
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return numbers;
        }
    }
}