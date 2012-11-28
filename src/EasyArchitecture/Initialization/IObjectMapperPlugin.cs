using System.Reflection;

namespace EasyArchitecture.Initialization
{
    public interface IObjectMapperPlugin
    {
        void Configure(Assembly assembly);
        T1 Map<T, T1>(T p0);
    }
}