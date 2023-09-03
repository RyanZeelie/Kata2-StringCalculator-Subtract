using Calculator.Services.Delimiters;
using Calculator.Services.Numbers;

namespace CalculatorTests
{
    [TestFixture]
    public class SubtractionServiceTests
    {
        private INumberService _numberService;

        [SetUp]
        public void Setup()
        {
            var subtractionDelimitierService = new SubtractionDelimiterService();
            _numberService = new SubtractionNumberService(subtractionDelimitierService);
        }

        [TestCase("1,2,3")]
        [TestCase("1\n2\n3")]
        public void GIVEN_StringOfNumbersSeperatedByDefaultDelimiters_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt(string input)
        {
            // Arrange
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("##%\n1%2%3")]
        [TestCase("####\n1##2##3")]
        public void GIVEN_StringOfNumbersSeperatedByCustomDelimiter_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt(string input)
        {
            // Arrange
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}
