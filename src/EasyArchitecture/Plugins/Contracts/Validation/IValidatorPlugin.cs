namespace EasyArchitecture.Plugins.Contracts.Validation
{
    public interface IValidatorPlugin:IConfigurablePlugin,IInstanceProvider<IValidator>
    {
    }
}