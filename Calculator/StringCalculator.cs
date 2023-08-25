using Calculator.Services;

namespace Calculator
{
    public class StringCalculator 
    {
        private readonly INumberService _numberService;

        private const int DefaultValue = 0;

        public StringCalculator(INumberService numberService)
        {
            _numberService = numberService;
        }

        public int Subtract(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return DefaultValue;
            }

            var subtractionResult = DefaultValue;

            var listOfNumbers = _numberService.ParseNumbers(input);
            
            foreach (var number in listOfNumbers) 
            {
                subtractionResult -= number;
            }

            return subtractionResult;
        }
    }
}