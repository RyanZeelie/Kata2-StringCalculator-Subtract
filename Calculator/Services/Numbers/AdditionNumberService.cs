using Calculator.Services.Delimiters;

namespace Calculator.Services.Numbers
{
    public class AdditionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "//";

        public AdditionNumberService(IDelimiterService delimiterService)
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
            var delimiters = _delimiterService.GetDelimiters(inputString, DelimiterIndicator);

            if (inputString.StartsWith(DelimiterIndicator))
            {
                var startIndexOfnumbers = inputString.IndexOf(DelimiterSeperator) + 1;
                var numberSectionOfstring = inputString.Substring(startIndexOfnumbers);

                return numberSectionOfstring.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            }

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
