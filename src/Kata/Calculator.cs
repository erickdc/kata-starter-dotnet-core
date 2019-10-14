using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var numbers = s.Split(",").Select(int.Parse);
            var enumerable = numbers.ToList();
            if (enumerable.Count() == 1)
            {
                return enumerable[0];
            }

            return enumerable[0] + enumerable[1];

        }
    }
}