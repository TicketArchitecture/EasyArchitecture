using System.Reflection;

namespace EasyArchitecture.Plugins
{
    public interface ITranslatorPlugin
    {
        void Configure(Assembly assembly);
        T1 Map<T, T1>(T p0);
        T1 Map<T, T1>(T p0, T1 p1);
    }
}