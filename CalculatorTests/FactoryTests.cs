using Calculator.Enums;
using Calculator.Factories;
using Calculator.Services.Numbers;

namespace CalculatorTests
{
    [TestFixture]
    public class NumberServiceFactoryTests
    {
        private INumberServiceFactory _numberServiceFactory;

        [SetUp]
        public void Setup()
        {
            _numberServiceFactory = new NumberServiceFactory(); 
        }

        [Test]
        public void GIVEN_AddOperationEnum_WHEN_CreatingInstanceOfNumberService_RETURNS_AdditionNumberService()
        {
            // Act
            var instanceOfAdditionNumberService = _numberServiceFactory.CreateNumberService(Operations.Add);

            //Asset
            Assert.IsInstanceOf<AdditionNumberService>(instanceOfAdditionNumberService);
        }


        [Test]
        public void GIVEN_SubtractOperationEnum_WHEN_CreatingInstanceOfNumberService_RETURNS_SubtractionNumberService()
        {
            // Act
            var instanceOfSubtractionNumberService = _numberServiceFactory.CreateNumberService(Operations.Subtract);

            //Asset
            Assert.IsInstanceOf<SubtractionNumberService>(instanceOfSubtractionNumberService);
        }
    }
}