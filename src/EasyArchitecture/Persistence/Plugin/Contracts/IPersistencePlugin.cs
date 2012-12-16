using System.Reflection;
using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Persistence.Plugin.Contracts
{
    public interface IPersistencePlugin:IConfigurablePlugin,IInstanceProvider<IPersistence>
    {
        void Configure(string moduleName, Assembly assembly);
    }
}