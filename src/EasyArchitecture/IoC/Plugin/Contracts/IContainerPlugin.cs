using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.IoC.Plugin.Contracts
{
    public interface IContainerPlugin:IConfigurablePlugin,IInstanceProvider<IContainer>
    {
    }
}