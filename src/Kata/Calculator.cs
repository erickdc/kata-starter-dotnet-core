using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            var delimiters = new String[]
            {
                ",",
                "\n"
            };
            var numbersInput = number;
            if (number.StartsWith("//"))
            {
                var inputParts = number.Split("\n");
                delimiters = new[] {inputParts[0].Replace("//", "")};
                numbersInput = inputParts[1];
            }
            var numbers = numbersInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
            if (numbers.Length > 1)
            {
                return numbers.Sum();
            }

            return numbers.First();
        }
    }
}