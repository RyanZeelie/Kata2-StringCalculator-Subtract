using Calculator.Constants;
using Calculator.Exceptions;
using Calculator.Services.Delimiters;
namespace Calculator.Services.Numbers
{
    public class SubtractionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "##";
        private const string CustomSeperatorIndicator = "<";
        private const int MaximumNumber = 1000;

        public SubtractionNumberService(IDelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public List<int> ParseNumbers(string inputString)
        {
            var numbersWithoutDelimiters = RemoveDelimitersFromInputString(inputString);

            var validatedNumbers = ValidateNumbers(numbersWithoutDelimiters);

            return validatedNumbers;
        }

        private string[] RemoveDelimitersFromInputString(string inputString)
        {
            var delimiters = _delimiterService.GetDelimiters(inputString, DelimiterIndicator);

            if (inputString.StartsWith(DelimiterIndicator) || inputString.StartsWith(CustomSeperatorIndicator))
            {
                var startIndexOfnumbers = inputString.IndexOf(DelimiterSeperator) + 1;
                var numberSectionOfstring = inputString.Substring(startIndexOfnumbers);

                return numberSectionOfstring.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            }

            return inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private List<int> ValidateNumbers(string[] numbers)
        {
            var validatedNumbers = ReplaceLetters(numbers);

            var parseNumbers = ParseNumbersToInt(validatedNumbers);

            CheckForNumbersGreaterThan1000(parseNumbers);

            return parseNumbers;
        }

        private List<string> ReplaceLetters(string[] numbers)
        {
            var listOfNumbers = new List<string>();

            foreach (var numberItem in numbers)
            {
                int parsedValue;

                if (!int.TryParse(numberItem, out parsedValue))
                {
                    var letterAsNumericalValue = char.ToLower(char.Parse(numberItem)) - 'a';

                    if (letterAsNumericalValue >= 0 && letterAsNumericalValue < 10)
                    {
                        listOfNumbers.Add(letterAsNumericalValue.ToString());
                    };
                }
                else
                {
                    listOfNumbers.Add(parsedValue.ToString());
                }
            }

            return listOfNumbers;
        }

        private List<int> ParseNumbersToInt(List<string> numbers)
        {
            var listOfIntNumbers = new List<int>();

            foreach (var number in numbers)
            {
                var parsedNumber = int.Parse(number);

                listOfIntNumbers.Add(parsedNumber);
            }

            return listOfIntNumbers;
        }

        public void CheckForNumbersGreaterThan1000(List<int> numbers)
        {
            var numbersGreaterThan1000 = new List<int>();

            foreach(var number in numbers)
            {
                if (number > MaximumNumber)
                {
                    numbersGreaterThan1000.Add(number);
                }
            }

            if (numbersGreaterThan1000.Count > 0)
            {
                throw new NumbersException(ErrorTypes.NumbersGreaterThan1000, numbersGreaterThan1000);
            }
        }
    }
}
