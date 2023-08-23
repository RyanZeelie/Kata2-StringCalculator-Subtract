using Calculator;
using Calculator.Services;
using NSubstitute;

namespace CalculatorTests
{
    public class CalculatorSubtractionTests
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

        [Test]
        public void GIVEN_AnUnkownAmountOfNumbers_WHEN_SubtractingStringNumbers_SHOULD_SubtractNumbers()
        {
            // Arrange
            var rndm = new Random();
            var randomAmountOfNumbersBetween1And10 = Enumerable.Range(1, rndm.Next(10));

            var input = string.Join(",", randomAmountOfNumbersBetween1And10);
            var expectedResult = GetSubtractionResult(randomAmountOfNumbersBetween1And10);

            _mockNumberService.ParseNumbers(input).Returns(randomAmountOfNumbersBetween1And10);

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

        private int GetSubtractionResult(IEnumerable<int> listOfNumbers)
        {
            var subtractionResult = 0;

            foreach (var number in listOfNumbers)
            {
                subtractionResult -= number;
            }

            return subtractionResult;
        }
    }
}