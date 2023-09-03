using Calculator.Enums;
using Calculator.Factories;
using Calculator.Services.Numbers;

namespace Calculator
{
    public class Calculator
    {
        private readonly INumberServiceFactory _numberServiceFactory;
        private INumberService _numberService;

        public Calculator(INumberServiceFactory numberServiceFactory)
        {
            _numberServiceFactory = numberServiceFactory;
        }

        public int Add()
        {
            _numberService = _numberServiceFactory.CreateNumberService(Operations.Add);
            return 1;
        }

        public int Subtract()
        {
            _numberService = _numberServiceFactory.CreateNumberService(Operations.Subtract);
            return 1;
        }
    }
}