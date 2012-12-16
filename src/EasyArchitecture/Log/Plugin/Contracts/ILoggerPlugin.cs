using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Log.Plugin.Contracts
{
    public interface ILoggerPlugin:IConfigurablePlugin,IInstanceProvider<ILogger>
    {
    }
}