namespace Calculator.Services.Delimiters
{
    public class SubtractionDelimiterService : IDelimiterService
    {
        public string[] GetDelimiters(string inputString)
        {
            var defaultDelimiters = new string[] { ",", "\n" };

            return defaultDelimiters;
        }
    }
}
