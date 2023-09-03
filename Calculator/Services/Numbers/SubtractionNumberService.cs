using Calculator.Services.Delimiters;
namespace Calculator.Services.Numbers
{
    public class SubtractionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "##";

        public SubtractionNumberService(IDelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public List<int> ParseNumbers(string inputString)
        {
            var numbersWithoutDelimiters = RemoveDelimitersFromInputString(inputString);

            var validatedNumbers = ValidateNumbers(numbersWithoutDelimiters);

            var listOfIntNumbers = ParseNumbersToInt(validatedNumbers);

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

        private List<string> ValidateNumbers(string[] numbers)
        {
            var numbersWithLettersRemoved = ReplaceLetters(numbers);

            return numbersWithLettersRemoved;
        }

        private List<string> ReplaceLetters(string[] numbers)
        {
            var listOfNumbers = new List<string>();

            foreach (var numberItem in numbers)
            {
                var letterAsNumericalValue = char.ToLower(char.Parse(numberItem)) - 'a'; ;

                if (letterAsNumericalValue >= 0 && letterAsNumericalValue < 10)
                {
                    listOfNumbers.Add(letterAsNumericalValue.ToString());
                };
            }

            return listOfNumbers;
        }

        private List<int> ParseNumbersToInt(List<string> numbers)
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
