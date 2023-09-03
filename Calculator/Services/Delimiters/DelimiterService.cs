namespace Calculator.Services.Delimiters
{
    public class DelimiterService : IDelimiterService
    {
        private const string DelimiterSeperator = "\n";

        public string[] GetDelimiters(string inputString, string delimiterIndicator)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (inputString.StartsWith(delimiterIndicator))
            {
                var customDelimiters = GetCustomDelimiters(inputString);
                delimiters.AddRange(customDelimiters);
            }

            return delimiters.ToArray();
        }

        private string[] GetCustomDelimiters(string input)
        {
            var delimiterIdenitifiers = new List<string>() { "[", "]", "][" };

            var delimiterStartIndex = 2;
            var delimiterEndIndex = input.IndexOf(DelimiterSeperator) - 2;

            var delimiterSectionOfInputString = input.Substring(delimiterStartIndex, delimiterEndIndex);
            var delimiters = delimiterSectionOfInputString.Split(delimiterIdenitifiers.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            return delimiters.ToArray();
        }
    }
}
