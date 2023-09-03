using Calculator.Enums;
using Calculator.Services.Numbers;

namespace Calculator.Factories
{
    public interface INumberServiceFactory
    {
        INumberService CreateNumberService(Operations operation);
    }
}
