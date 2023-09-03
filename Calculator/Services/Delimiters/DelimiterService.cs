namespace Calculator.Services.Delimiters
{
    public class DelimiterService : IDelimiterService
    {
        private const string DelimiterSeperator = "\n";
        private const string CustomDelimiterIdentifierIndicator = "<";

        public string[] GetDelimiters(string inputString, string delimiterIndicator)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (inputString.StartsWith(delimiterIndicator) || inputString.StartsWith(CustomDelimiterIdentifierIndicator))
            {
                var customDelimiters = GetCustomDelimiters(inputString, delimiterIndicator);
                delimiters.AddRange(customDelimiters);
            }

            return delimiters.ToArray();
        }

        private string[] GetCustomDelimiters(string input, string delimiterIndicator)
        {
            var delimiterIdenitifiers = new List<string>() { "[", "]", "][" };

            var delimiterStartIndex = 2;
            var delimiterEndIndex = input.IndexOf(DelimiterSeperator) - 2;

            if (input.StartsWith(CustomDelimiterIdentifierIndicator))
            {
                delimiterIdenitifiers = ReplaceDefaultDelimiterIdentifiers(input);

                delimiterStartIndex = input.IndexOf(delimiterIndicator) + 2;
                delimiterEndIndex  = input.IndexOf(DelimiterSeperator);
            }

            var delimiterSectionOfInputString = input.Substring(delimiterStartIndex, delimiterEndIndex);

            var delimiters = delimiterSectionOfInputString.Split(delimiterIdenitifiers.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            return delimiters.ToArray();
        }

        private List<string> ReplaceDefaultDelimiterIdentifiers(string input)
        {
            var newDelimiterIdentifiersStartCharacter = input[1].ToString();
            var newDelimiterIdentifiersEndCharacter = input[3].ToString();

            return
                new List<string>()
                {
                    newDelimiterIdentifiersStartCharacter,
                    newDelimiterIdentifiersEndCharacter,
                    $"{newDelimiterIdentifiersEndCharacter}{newDelimiterIdentifiersStartCharacter}"
                };
        }
    }
}
