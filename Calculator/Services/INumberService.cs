namespace Calculator.Services
{
    public interface INumberService
    {
        IEnumerable<int> ParseNumbers(string input);
    }
}
