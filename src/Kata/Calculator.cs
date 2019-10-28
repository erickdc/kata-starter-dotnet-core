using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var delimeters = new [] { ",", "\n"};
            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");
                delimeters = new[] {parts[0].Replace("//", "").Replace("[","").Replace("]","")};
                s = parts[1];
            }
            var numbers = s.Split(delimeters, StringSplitOptions.None).Select(int.Parse).Where(n => n < 1001);
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Count() > 0)
            {
                 throw new Exception($"negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
            return numbers.Sum();
        }
    }
}