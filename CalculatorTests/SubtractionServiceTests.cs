using Calculator.Exceptions;
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
            var delimiterService = new DelimiterService();
            _numberService = new SubtractionNumberService(delimiterService);
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

        [Test]
        public void GIVEN_StringOfNumbersSeperatedByMultipleCustomDelimiters_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt()
        {
            // Arrange
            var input = "##[%][;]\n1;2%3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_StringOfNumbersSeperatedByDelimitierOfAnyLength_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt()
        {
            // Arrange
            var input = "##[***][;;;;]\n1;;;;2***3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_Letters_WHEN_ParsingNumbers_SHOULD_ReplaceLettersWithNumbers()
        {
            // Arrange
            var input = "k,a,b,c,d,e,f,g,h,i,j,k";
            var expectedResult = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_NumbersGreaterThan1000_WHEN_SubtractingStringNumbers_THROWS_NumbersExceptionAllNumbersGreaterThan1000()
        {
            // Arrange
            var input = "1,1001,1002";
            var expectedResult = "The following numbers were greater than 1000 : 1001, 1002";

            // Act
            var exception = Assert.Throws<NumbersException>(() => _numberService.ParseNumbers(input));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedResult));
        }

        [TestCase("<{>}##{%}\n2%3%4")]
        [TestCase("<[>}##[%}\n2%3%4")]
        [TestCase("<>><##>%<\n2%3%4")]
        [Test]
        public void GIVEN_CustomDelimiterSeperators_WHEN_SubtractingStringNumbers_RETURNS_ListOfNumbersAsInt(string input)
        {
            // Arrange
            var expectedResult = new List<int>() { 2, 3, 4 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}
