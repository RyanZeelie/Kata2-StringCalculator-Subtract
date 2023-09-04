using Calculator.Constants;
using Calculator.Exceptions;
using Calculator.Services.Delimiters;

namespace Calculator.Services.Numbers
{
    public class AdditionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "//";
        private const int MaximumNumber = 1000;

        public AdditionNumberService(IDelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public List<int> ParseNumbers(string inputString)
        {
            var numbersWithoutDelimiters = RemoveDelimitersFromInputString(inputString);

            var listOfValidatedNumbers = ValidateNumbers(numbersWithoutDelimiters);

            return listOfValidatedNumbers;
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

        private List<int> ValidateNumbers(string[] numbers)
        {
            List<int> validatedNumbers;

            validatedNumbers = ParseNumbersToInt(numbers);

            validatedNumbers = RemoveNumbersGreaterThan1000(validatedNumbers);

            CheckForNegativeNumbers(validatedNumbers);

            return validatedNumbers;
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

        private List<int> RemoveNumbersGreaterThan1000(List<int> numbers)
        {
            var numbersLessThan1000 = new List<int>();

            foreach (var number in numbers)
            {
                if (number < MaximumNumber)
                {
                    numbersLessThan1000.Add(number);
                }
            }

            return numbersLessThan1000;
        }

        private void CheckForNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new NumbersException(ErrorTypes.NegativeNumbers, negativeNumbers);
            }
        }
    }
}
