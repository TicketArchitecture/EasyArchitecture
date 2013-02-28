using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Validation
{
    public interface IValidatorPlugin:IConfigurablePlugin,IInstanceProvider<IValidator>
    {
    }
}