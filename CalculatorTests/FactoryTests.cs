using Calculator.Enums;
using Calculator.Factories;
using Calculator.Services.Numbers;

namespace CalculatorTests
{
    [TestFixture]
    public class FactoryTests
    {
        private INumberServiceFactory _numberServiceFactory;

        [SetUp]
        public void Setup()
        {
            _numberServiceFactory = new NumberServiceFactory(); 
        }

        [Test]
        public void GIVEN_AddOperationEnum_WHEN_CreatingInstanceOfNumberService_RETURNS_CorrectNumberService()
        {
            //Arrange

            // Act
            var instanceOfAdditionNumberService = _numberServiceFactory.CreateNumberService(Operations.Add);

            //Asset
            Assert.IsInstanceOf<AdditionNumberService>(instanceOfAdditionNumberService);
        }


        [Test]
        public void GIVEN_SubtractOperationEnum_WHEN_CreatingInstanceOfNumberService_RETURNS_CorrectNumberService()
        {
            //Arrange

            // Act
            var instanceOfSubtractionNumberService = _numberServiceFactory.CreateNumberService(Operations.Subtract);

            //Asset
            Assert.IsInstanceOf<SubtractionNumberService>(instanceOfSubtractionNumberService);
        }
    }
}