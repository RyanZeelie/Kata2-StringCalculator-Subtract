namespace Calculator.Services.Delimiters
{
    public class AdditionDelimiterService : IDelimiterService
    {
        public string[] GetDelimiters(string inputString)
        {
            var defaultDelimiters = new string[] { ",", "\n" };

            return defaultDelimiters;
        }
    }
}
