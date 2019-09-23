using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (string.IsNullOrEmpty(number)) return 0;
            var delimeters = new []{",", "\n"};
            var inputString = number;
            if (number.StartsWith("//"))
            {
                var parts = number.Split(("\n"));
                delimeters = new[] {parts[0].Replace("//", "")};
                inputString = parts[1];
            }
            
            var numbers = inputString.Split(delimeters, StringSplitOptions.None).Select((int.Parse)).Where(n => n <= 1000).ToArray();
            var negativesNumbers = numbers.Where(n => n < 0).ToArray();
            if (negativesNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negativesNumbers)}");
            }
            if (numbers.Length > 1)
            {
                return numbers.Sum();
            }

            
            return numbers[0];
        }
    }
}