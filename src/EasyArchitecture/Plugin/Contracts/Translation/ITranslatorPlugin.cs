using EasyArchitecture.Core.Plugin;

namespace EasyArchitecture.Plugin.Contracts.Translation
{
    public interface ITranslatorPlugin : IInstanceProvider<ITranslator>, IConfigurablePlugin
    {
    }
}