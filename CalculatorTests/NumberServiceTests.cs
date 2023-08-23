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
    }
}
