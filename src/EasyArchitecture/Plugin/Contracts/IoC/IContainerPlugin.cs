using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.IoC
{
    public interface IContainerPlugin:IConfigurablePlugin,IInstanceProvider<IContainer>
    {
    }
}