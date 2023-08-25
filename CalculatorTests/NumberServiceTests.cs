using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Services;

namespace CalculatorTests
{
    [TestFixture]
    public class NumberServiceTests
    {
        private INumberService _numberService;

        [SetUp]
        public void Setup()
        {
            _numberService = new NumberService();
        }

        [Test]
        public void GIVEN_StringOfNumbersSeperatedByComma_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt()
        {
            // Arrange
            var input = "1,2,3";
            var expectedResult = new List<int>(){ 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));    
        }

        [Test]
        public void GIVEN_StringOfNumbersSeperatedByNewLine_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt()
        {
            // Arrange
            var input = "1\n2\n3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_StringOfNumbersSeperatedByCustomDelimiter_WHEN_ParsingNumbers_RETURNS_ListOfNumbersAsInt()
        {
            // Arrange
            var input = "##%\n1%2%3";
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
            var input = "a,b,c,d,e,f,g,h,i,j";
            var expectedResult = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_LettersOutOfSpecRange_WHEN_ParsingNumbers_SHOULD_IgnoreLetters()
        {
            // Arrange
            var input = "k,l,m";
            var expectedResult = new List<int>() { };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void GIVEN_LettersAndNumbers_WHEN_ParsingNumbers_SHOULD_ReplaceLettersWithNumbers()
        {
            // Arrange
            var input = "1,c,3";
            var expectedResult = new List<int>() { 1, 2, 3 };

            // Act
            var result = _numberService.ParseNumbers(input);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}
