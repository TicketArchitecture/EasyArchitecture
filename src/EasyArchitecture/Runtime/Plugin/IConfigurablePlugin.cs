using System.Reflection;

namespace EasyArchitecture.Runtime.Plugin
{
    public interface IConfigurablePlugin
    {
        void Configure(Assembly assembly);
    }
}