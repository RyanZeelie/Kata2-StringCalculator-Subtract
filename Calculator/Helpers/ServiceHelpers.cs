namespace Calculator.Helpers
{
    public static class ServiceHelpers
    {
        public static List<int> ParseNumbersToInt(string[] numbers)
        {
            var listOfNumbers = new List<int>();

            foreach (var number in numbers)
            {
                var parsedNumber = int.Parse(number);

                listOfNumbers.Add(parsedNumber);
            }

            return listOfNumbers;
        }

        public static string GetNumberSectionOfString(string inputString)
        {
            var delimiterSeperator = "\n";

            var startIndexOfnumbers = inputString.IndexOf(delimiterSeperator) + 1;
            var numberSectionOfstring = inputString.Substring(startIndexOfnumbers);

            return numberSectionOfstring;
        }
    }
}
