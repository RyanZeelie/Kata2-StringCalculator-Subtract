using Calculator.Enums;
using Calculator.Factories;
using Calculator.Services.Numbers;

namespace Calculator
{
    public class StringCalculator
    {
        private readonly INumberServiceFactory _numberServiceFactory;
        private INumberService _numberService;

        private const int DefaultValue = 0;

        public StringCalculator(INumberServiceFactory numberServiceFactory)
        {
            _numberServiceFactory = numberServiceFactory;
        }

        public int Add(string inputString)
        {
            _numberService = _numberServiceFactory.CreateNumberService(Operations.Add);

            var numbers = _numberService.ParseNumbers(inputString);

            var additionResult = DefaultValue;

            foreach (var number in numbers)
            {
                additionResult += number;
            }

            return additionResult;
        }

        public int Subtract(string inputString)
        {
            _numberService = _numberServiceFactory.CreateNumberService(Operations.Subtract);

            var numbers = _numberService.ParseNumbers(inputString);

            var additionResult = DefaultValue;

            foreach (var number in numbers)
            {
                additionResult -= number;
            }

            return additionResult;
        }
    }
}