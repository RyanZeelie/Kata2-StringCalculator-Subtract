using Calculator.Enums;
using Calculator.Exceptions;
using Calculator.Factories;
using Calculator.Services.Delimiters;
using Calculator.Services.Numbers;
using NSubstitute;

namespace CalculatorTests
{
    [TestFixture]
    public class AdditionNumberServiceTests
    {
        private INumberServiceFactory _mockNumberServiceFactory;
        private INumberService _numberService;


        [SetUp]
        public void Setup()
        {
            _mockNumberServiceFactory = Substitute.For<INumberServiceFactory>();
            _mockNumberServiceFactory.CreateNumberService(Operations.Add).Returns(CreateNumberService());

            _numberService = _mockNumberServiceFactory.CreateNumberService(Operations.Add);
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

        [TestCase("//%\n1%2%3")]
        [TestCase("////\n1//2//3")]
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
            var input = "//[%][;]\n1;2%3";
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
            var input = "//[***][;;;;]\n1;;;;2***3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_AnegativeNumber_WHEN_ParsingNumbers_THROWS_NumbersException()
        {
            // Arrange
            var testInput = "1,2,-3,4";
            var expectedResult = "Negatives Are Not Allowed : -3";

            //Act
            var exception = Assert.Throws<NumbersException>(() => _numberService.ParseNumbers(testInput));

            //Assert
            Assert.That(exception.Message, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_NumbersGreaterThan1000_WHEN_ParsingNumbers_RETRUNS_ListOfNumbersExcludingThoseGreaterThan1000()
        {
            // Arrange
            var testInput = "1,1001,1002,2";
            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GIVEN_ADelimiterTheSameAsTheDelimiterStartString_WHEN_ParsingNumbers_RETRUNS_NumbersAsListInt()
        {
            // Arrange
            var testInput = "////\n1//2//3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            //Act
            var result = _numberService.ParseNumbers(testInput);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private INumberService CreateNumberService()
        {
            var delimiterService = new AdditionDelimiterService();
            var numberService = new AdditionNumberService(delimiterService);

            return numberService;
        }
    }
}
