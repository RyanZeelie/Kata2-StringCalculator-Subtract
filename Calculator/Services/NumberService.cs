namespace Calculator.Services
{
    public class NumberService : INumberService
    {
        public string[] _delimiters = new string[] { ",", "\n" };

        public IEnumerable<int> ParseNumbers(string input)
        {
            var splitNumbers = input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            var parsedNumbers = ValidateAndParseNumbers(splitNumbers);

            return parsedNumbers;
        }

        private IEnumerable<int> ValidateAndParseNumbers(IEnumerable<string> stringOfNumbers)
        {
            var listOfNumbers = new List<int>();  

            foreach (var number in stringOfNumbers)
            {
                var parsedNumber = int.Parse(number);

                listOfNumbers.Add(parsedNumber);
            }

            return listOfNumbers;
        }
    }
}
