using Calculator.Enums;
using Calculator.Services.Delimiters;
using Calculator.Services.Numbers;

namespace Calculator.Factories
{
    public class NumberServiceFactory : INumberServiceFactory
    {
        private readonly IDelimiterService _delimiterService;

        public NumberServiceFactory(IDelimiterService delimiterService)
        {
            _delimiterService  = delimiterService;
        }

        public INumberService CreateNumberService(Operations operation)
        {
            return operation switch
            {
                Operations.Add => new AdditionNumberService(_delimiterService),
                Operations.Subtract => new SubtractionNumberService(_delimiterService),
                _ => throw new Exception("Invalid operation")
            };
        }
    }
}
