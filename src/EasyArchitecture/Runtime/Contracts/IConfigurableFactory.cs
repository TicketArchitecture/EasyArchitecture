using EasyArchitecture.Configuration.Expressions;

namespace EasyArchitecture.Runtime.Contracts
{
    internal interface IConfigurableFactory
    {
        void Configure(ConfigHelper plugin);
    }
}