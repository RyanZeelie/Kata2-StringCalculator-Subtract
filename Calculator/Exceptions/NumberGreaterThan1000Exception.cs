namespace Calculator.Exceptions
{
    public class NumberGreaterThan1000Exception : Exception
    {
        public NumberGreaterThan1000Exception() { }

        public NumberGreaterThan1000Exception(List<int> invalidNumbers)
            : base(String.Format($"The following numbers were greater than 1000 : {string.Join(", ", invalidNumbers)}"))
        {

        }
    }
}
