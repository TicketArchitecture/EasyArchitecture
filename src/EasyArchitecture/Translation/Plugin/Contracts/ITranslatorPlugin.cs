using System.Reflection;

namespace EasyArchitecture.Translation.Plugin.Contracts
{
    public interface ITranslatorPlugin
    {
        void Configure(Assembly assembly);
        T1 Translate<T, T1>(T p0);
        T1 Translate<T, T1>(T p0, T1 p1);
    }
}