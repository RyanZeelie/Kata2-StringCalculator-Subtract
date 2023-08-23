using Calculator;
using Calculator.Services;

namespace CalculatorTests
{
    public class Tests
    {
        private readonly INumberService _numberService;
        private StringCalculator _calculator; 

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator(_numberService);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}