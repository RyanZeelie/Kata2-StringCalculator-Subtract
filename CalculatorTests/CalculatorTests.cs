using Calculator;
using Calculator.Services;
using NSubstitute;

namespace CalculatorTests
{
    public class Tests
    {
        private INumberService _mockNumberService;
        private StringCalculator _calculator; 

        [SetUp]
        public void Setup()
        {
            _mockNumberService = Substitute.For<INumberService>();
            _calculator = new StringCalculator(_mockNumberService);
        }

        [Test]
        public void GIVEN_ListOfStringNumbers_WHEN_SubtractingStringNumbers_SHOULD_SubtractNumbers()
        {
            // Arrange
            var input = "1,2,3";
            var expectedResult = -6;

            _mockNumberService.ParseNumbers(input).Returns(new List<int>() { 1, 2, 3 });

            // Act
            var result = _calculator.Subtract(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));    
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void GIVEN_NullOrEmptyString_WHEN_SubtractingStringNumbers_Returns_Zero(string input)
        {
            // Arrange
            var expectedResult = 0;

            // Act
            var result = _calculator.Subtract(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}