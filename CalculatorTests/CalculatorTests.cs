using Calculator;
using Calculator.Enums;
using Calculator.Factories;
using Calculator.Services.Numbers;
using NSubstitute;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private INumberServiceFactory _mockNumberServiceFactory;
        private INumberService _mockNumberService;

        private StringCalculator _calculator;

        [SetUp] 
        public void SetUp() 
        {
            _mockNumberServiceFactory = Substitute.For<INumberServiceFactory>();
            _mockNumberService = Substitute.For<INumberService>();

            _mockNumberServiceFactory.CreateNumberService(Operations.Add).Returns(_mockNumberService);
            _mockNumberServiceFactory.CreateNumberService(Operations.Subtract).Returns(_mockNumberService);

            _calculator = new StringCalculator(_mockNumberServiceFactory);
        }

        [Test]
        public void GIVEN_StringNumbersSeperatedByComma_WHEN_AddingStringNumbers_SHOULD_AddNumbers()
        {
            // Arrange
            var input = "1,2,3";
            var expectedResult = 6;

            _mockNumberService.ParseNumbers(input).Returns(new List<int>() { 1, 2, 3 });

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

            _mockNumberService.ParseNumbers(input).Returns(new List<int>() { 1, 2, 3 });

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

            _mockNumberService.ParseNumbers(input).Returns(new List<int>() { 1, 2, 3 });

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

            _mockNumberService.ParseNumbers(input).Returns(new List<int>() { 1, 2, 3 });

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

            // Assert
            Assert.That(expectedResult, Is.EqualTo(subtractionResult));
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void GIVEN_NullOrEmptyString_WHEN_AddingStringNumbers_Returns_Zero(string input)
        {
            // Arrange
            var expectedResult = 0;

            // Act
            var additionResult = _calculator.Add(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(additionResult));
        }
    }
}
