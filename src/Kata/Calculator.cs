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

            var numbers = number.Split(',');
            if (numbers.Length > 1)
            {
                return  int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }
            return int.Parse(number);

        }
    }
}