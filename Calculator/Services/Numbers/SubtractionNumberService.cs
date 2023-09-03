using Calculator.Services.Delimiters;

namespace Calculator.Services.Numbers
{
    public class SubtractionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        public SubtractionNumberService(IDelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public List<int> ParseNumbers(string inputString)
        {
            var numbersWithoutDelimiters = RemoveDelimitersFromInputString(inputString);

            var listOfIntNumbers = ParseNumbersToInt(numbersWithoutDelimiters);

            return listOfIntNumbers;
        }

        private string[] RemoveDelimitersFromInputString(string inputString)
        {
            var delimiters = _delimiterService.GetDelimiters(inputString);

            return inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        }

        private List<int> ParseNumbersToInt(string[] numbers)
        {
            var listOfNumbers = new List<int>();

            foreach (var number in numbers)
            {
                var parsedNumber = int.Parse(number);

                listOfNumbers.Add(parsedNumber);
            }

            return listOfNumbers;
        }
    }
}
