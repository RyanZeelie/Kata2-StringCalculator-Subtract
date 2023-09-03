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
    }
}
