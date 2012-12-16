using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Runtime.Contracts
{
    internal interface IConfigurableFactory
    {
        void Configure(PluginConfiguration plugin);
    }
}