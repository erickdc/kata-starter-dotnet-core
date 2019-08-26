using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;

            var numbers = number.Split(new string[] {",", "\n"},
                    StringSplitOptions.None)
                .Select(int.Parse).ToArray();
            return numbers.Sum();
        }
    }
}