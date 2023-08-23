using Calculator.Services;

namespace Calculator
{
    public class StringCalculator 
    {
        private readonly INumberService _numberService;
        public StringCalculator(INumberService numberService)
        {
            _numberService = numberService;
        }
    }
}