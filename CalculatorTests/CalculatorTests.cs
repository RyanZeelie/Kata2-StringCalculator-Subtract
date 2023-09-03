using Calculator;
using Calculator.Factories;
using Calculator.Services.Numbers;
using NSubstitute;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private INumberServiceFactory _numberServiceFactory;
        private StringCalculator _calculator;

        [SetUp] 
        public void SetUp() 
        {
            _numberServiceFactory = new NumberServiceFactory();
            _calculator = new StringCalculator(_numberServiceFactory);
        }

        [Test]
        public void GIVEN_StringNumbersSeperatedByComma_WHEN_AddingStringNumbers_SHOULD_AddNumbers()
        {
            // Arrange
            var input = "1,2,3";
            var expectedResult = 6;

            // Act
            var result = _calculator.Add(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_StringNumbersSeperatedByComma_WHEN_SubtractingStringNumbers_SHOULD_SubtractNumbers()
        {
            // Arrange
            var input = "1,2,3";
            var expectedResult = -6;

            // Act
            var result = _calculator.Subtract(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_StringNumbersSeperatedByNewLine_WHEN_SubtractingStringNumbers_SHOULD_SubtractNumbers()
        {
            // Arrange
            var input = "1\n2\n3";
            var expectedResult = -6;

            // Act
            var result = _calculator.Subtract(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_StringNumbersSeperatedByNewLine_WHEN_AddingStringNumbers_SHOULD_AddNumbers()
        {
            // Arrange
            var input = "1\n2\n3";
            var expectedResult = 6;

            // Act
            var result = _calculator.Add(input);

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
            var subtractionResult = _calculator.Subtract(input);
            var additionResult = _calculator.Add(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(subtractionResult));
            Assert.That(expectedResult, Is.EqualTo(additionResult));
        }
    }
}
