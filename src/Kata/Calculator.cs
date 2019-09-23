namespace Kata
{
    public class Calculator
    {
        public int Add(string number = "")
        {
            if (string.IsNullOrEmpty(number)) return 0;
            return int.Parse(number);
        }
    }
}