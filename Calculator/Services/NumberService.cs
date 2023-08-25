namespace Calculator.Services
{
    public class NumberService : INumberService
    {
        private List<string> _delimiters = new List<string>() { ",", "\n"};

        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "##";
        private string[] DelimiterSurroundings = new string[] { "[", "]", "][" };

        public IEnumerable<int> ParseNumbers(string input)
        {
            var stringNumbers = GetStringNumbers(input);

            var parsedNumbers = ValidateAndParseNumbers(stringNumbers);

            return parsedNumbers;
        }

        private string[] GetStringNumbers(string input)
        {
            if (input.StartsWith(DelimiterIndicator))
            {
                var splitByNewLine = input.Replace(DelimiterIndicator,string.Empty).Split(DelimiterSeperator, StringSplitOptions.RemoveEmptyEntries);

                SetDelimitiers(splitByNewLine[0].Split(DelimiterSurroundings,StringSplitOptions.RemoveEmptyEntries));

                return splitByNewLine[1].Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            return input.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetDelimitiers(string[] delimiters)
        {
            foreach (var delimiter in delimiters)
            {
                _delimiters.Add(delimiter);
            }
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
