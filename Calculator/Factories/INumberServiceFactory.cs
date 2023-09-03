using Calculator.Services.Numbers;

namespace Calculator.Factories
{
    public interface INumberServiceFactory
    {
        INumberService CreateNumberService(string operation);
    }
}
