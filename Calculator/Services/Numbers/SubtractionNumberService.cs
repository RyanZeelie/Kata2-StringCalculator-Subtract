using Calculator.Enums;
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

            var parsedNumbers = ParseNumbersToInt(validatedNumbers);

            CheckForNumbersGreaterThan1000(parsedNumbers);

            var allPositiveNumbers = InvertNegatives(parsedNumbers);

            return allPositiveNumbers;
        }

        private List<string> ReplaceLetters(string[] numbers)
        {
            var listOfNumbersWithLettersReplaced = new List<string>();

            foreach (var numberItem in numbers)
            {
                int parsedValue;

                if (!int.TryParse(numberItem, out parsedValue))
                {
                    var letterAsNumericalValue = char.ToLower(char.Parse(numberItem)) - 'a';

                    if (letterAsNumericalValue >= 0 && letterAsNumericalValue < 10)
                    {
                        listOfNumbersWithLettersReplaced.Add(letterAsNumericalValue.ToString());
                    };
                }
                else
                {
                    listOfNumbersWithLettersReplaced.Add(parsedValue.ToString());
                }
            }

            return listOfNumbersWithLettersReplaced;
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

        private void CheckForNumbersGreaterThan1000(List<int> numbers)
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

        private List<int> InvertNegatives(List<int> numbers)
        {
            List<int> listOfPositiveNumbers = new(); 
            foreach (var number in numbers)
            {
                var validPositiveNumber = number < 0 ? Math.Abs(number) : number;
             
                listOfPositiveNumbers.Add(validPositiveNumber);
            }

            return listOfPositiveNumbers;
        }
    }
}
