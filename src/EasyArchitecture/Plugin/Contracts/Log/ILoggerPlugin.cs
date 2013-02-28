using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Log
{
    public interface ILoggerPlugin:IConfigurablePlugin,IInstanceProvider<ILogger>
    {
    }
}