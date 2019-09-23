using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (string.IsNullOrEmpty(number)) return 0;
            var numbers = number.Split(",").Select((int.Parse)).ToArray();
            if (numbers.Length > 1)
            {
                return numbers[0] + numbers[1];
            }
            return numbers[0];
        }
    }
}