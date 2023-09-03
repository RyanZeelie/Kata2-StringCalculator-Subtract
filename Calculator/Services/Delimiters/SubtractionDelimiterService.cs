namespace Calculator.Services.Delimiters
{
    public class SubtractionDelimiterService : IDelimiterService
    {
        private const string DelimiterSeperator = "\n";
        private const string DelimiterIndicator = "##";

        public string[] GetDelimiters(string inputString)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (inputString.StartsWith(DelimiterIndicator))
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
