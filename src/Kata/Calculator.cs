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
            var numbers = s.Split(delimeters, StringSplitOptions.None).Select(int.Parse);
            return numbers.Sum();
        }
    }
}