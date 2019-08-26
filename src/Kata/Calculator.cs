using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;

            var separator = new string[] {",", "\n"};
            var input = number;
            if (number.StartsWith("//"))
            {
                var inputParts = number.Split("\n").ToArray();
                separator = new [] {inputParts[0].Replace("//", "")};
                input = inputParts[1];
            }

            var numbers = input.Split(separator,
                    StringSplitOptions.None)
                .Select(int.Parse).ToArray();
            return numbers.Sum();
        }
    }
}