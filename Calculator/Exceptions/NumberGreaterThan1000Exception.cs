namespace Calculator.Exceptions
{
    public class NumberGreaterThan1000Exception : Exception
    {
        public NumberGreaterThan1000Exception() { }

        public NumberGreaterThan1000Exception(List<int> numbersGreaterThan1000)
            : base(String.Format($"The following numbers were greater than 1000 : {string.Join(", ", numbersGreaterThan1000)}"))
        {

        }
    }
}
