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
                Operations.Add => InstantiateAdditionNumberServiceInstanceAndInjectDelimiterService(),
                Operations.Subtract => InstantiateSubtractionNumberServiceInstanceAndInjectDelimiterService(),
                _ => throw new Exception("Invalid operation")
            };
        }

        private INumberService InstantiateAdditionNumberServiceInstanceAndInjectDelimiterService()
        {
            var additionDelimiterService = new AdditionDelimiterService();

            return new AdditionNumberService(additionDelimiterService);
        }

        private INumberService InstantiateSubtractionNumberServiceInstanceAndInjectDelimiterService()
        {
            var subtractionDelimiterService = new SubtractionDelimiterService();

            return new SubtractionNumberService(subtractionDelimiterService);
        }
    }
}
