using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public interface IValidatorPlugin:IConfigurablePlugin,IInstanceProvider<IValidator>
    {
    }
}