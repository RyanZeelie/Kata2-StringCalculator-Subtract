using Calculator.Enums;
using Calculator.Services.Delimiters;
using Calculator.Services.Numbers;

namespace Calculator.Factories
{
    public class NumberServiceFactory : INumberServiceFactory
    {
        public INumberService CreateNumberService(Operations operation)
        {
            return operation switch
            {
                Operations.Add => CreateAdditionNumberService(),
                Operations.Subtract => CreateSubtractionNumberService(),
                _ => throw new Exception("Invalid operation provided")
            };
        }

        private INumberService CreateAdditionNumberService()
        {
            var delmiterService = new AdditionDelimiterService();

            return new AdditionNumberService(delmiterService);
        }

        private INumberService CreateSubtractionNumberService()
        {
            var delmiterService = new SubtractionDelimiterService();

            return new SubtractionNumberService(delmiterService);
        }
    }
}
