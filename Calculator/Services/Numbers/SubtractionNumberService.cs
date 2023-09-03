using Calculator.Services.Delimiters;

namespace Calculator.Services.Numbers
{
    public class SubtractionNumberService : INumberService
    {
        private IDelimiterService _delimiterService;

        public SubtractionNumberService(IDelimiterService delimiterService)
        {
            _delimiterService = delimiterService;
        }

        public List<int> ParseNumbers(string inputString)
        {
            throw new NotImplementedException();
        }
    }
}
