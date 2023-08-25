using Calculator.Enums;
using Calculator.Exceptions;

namespace Calculator.Services
{
    public class NumberService : INumberService
    {
        private List<string> _delimiters = new List<string>() { ",", "\n"};
        private string[] _delimiterIdentifiers = new string[] { "[", "]", "][" };

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "##";
        private const string CustomDelimiterIdentifierIndicator = "<";

        public IEnumerable<int> ParseNumbers(string input)
        {
            var stringNumbers = GetNumbers(input);

            var parsedNumbers = ValidateAndParseNumbers(stringNumbers);

            return parsedNumbers;
        }

        private IEnumerable<string> GetNumbers(string input)
        {
            if (input.StartsWith(DelimiterIndicator) || input.StartsWith(CustomDelimiterIdentifierIndicator))
            {
                GetCustomDelimiters(input);

                return GetNumbersSeperatedByCustomDelimiters(input);
            }
           
            return input.Split(_delimiters.ToArray(),StringSplitOptions.RemoveEmptyEntries);
        }

        private void GetCustomDelimiters(string input)
        {
            if (input.StartsWith(CustomDelimiterIdentifierIndicator))
            {
                ReplaceDefaultDelimiterIdentifiers(input);
            }

            var delimiterStartIndex = 2;
            var delimiterEndIndex = input.IndexOf(DelimiterSeperator) - 2;

            var delimiters = input.Substring(delimiterStartIndex, delimiterEndIndex).Split(_delimiterIdentifiers, StringSplitOptions.RemoveEmptyEntries);

            foreach (var delimiter in delimiters)
            {
                _delimiters.Add(delimiter);
            }
        }

        private void ReplaceDefaultDelimiterIdentifiers(string input)
        {
            var newDelimiterIdentifiersStartCharacter = input[1].ToString();
            var newDelimiterIdentifiersEndCharacter = input[3].ToString();

            _delimiterIdentifiers = 
                new string[] 
                { 
                    newDelimiterIdentifiersStartCharacter,
                    newDelimiterIdentifiersEndCharacter,
                    $"{newDelimiterIdentifiersEndCharacter}{newDelimiterIdentifiersStartCharacter}" 
                };
        }

        private IEnumerable<string> GetNumbersSeperatedByCustomDelimiters(string inputString)
        {
            var numbersStartIndex = inputString.IndexOf(DelimiterSeperator) + 1;

            return inputString.Substring(numbersStartIndex).Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private List<string> FindAndReplaceLetters(List<string> stringOfNumbers)
        {
            var newListOfNumbers = new List<string>(stringOfNumbers);
            
            foreach (var item in stringOfNumbers)
            {
                if (Enum.TryParse(item, true, out LetterMapEnum numericalResult))
                {
                    var index = stringOfNumbers.IndexOf(item);
                    int letterValue = (int)numericalResult;

                    newListOfNumbers[index] = letterValue.ToString();
                }
                else
                {
                    newListOfNumbers.Remove(item);
                }
            }

            return newListOfNumbers;
        }

        private IEnumerable<int> ValidateAndParseNumbers(IEnumerable<string> stringOfNumbers)
        {
            var negativeNumbers = new List<int>();  

            var numbersWithLettersReplaced = FindAndReplaceLetters(stringOfNumbers.ToList());

            var listOfNumbers = new List<int>();  

            foreach (var number in numbersWithLettersReplaced)
            {
                var parsedNumber = int.Parse(number);

                if (parsedNumber > 1000)
                {
                    negativeNumbers.Add(parsedNumber);
                }

                listOfNumbers.Add(parsedNumber > 0 ? parsedNumber : parsedNumber * -1);
            }

            if (negativeNumbers.Count > 0)
            {
                throw new NumberGreaterThan1000Exception(negativeNumbers);
            }

            return listOfNumbers;
        }
    }
}
