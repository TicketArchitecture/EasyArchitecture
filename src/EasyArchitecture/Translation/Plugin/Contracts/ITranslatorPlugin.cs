using EasyArchitecture.Runtime.Plugin;

namespace EasyArchitecture.Translation.Plugin.Contracts
{
    public interface ITranslatorPlugin : IInstanceProvider<ITranslator>, IConfigurablePlugin
    {
    }
}