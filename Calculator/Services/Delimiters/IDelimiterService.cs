namespace Calculator.Services.Delimiters
{
    public interface IDelimiterService
    {
        string[] GetDelimiters(string inputString, string delimiterIndicator);
    }
}
