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

            var delimeters = new String[]
            {
                ",",
                "\n"
            };
            var numbers = number.Split(delimeters, StringSplitOptions.None).Select(int.Parse).ToArray();
            if (numbers.Length > 1)
            {
                return numbers.Sum();
            }
            return numbers.First();

        }
    }
}