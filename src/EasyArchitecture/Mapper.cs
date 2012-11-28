using EasyArchitecture.Initialization;

namespace EasyArchitecture
{
    public static class Mapper
    {
        public static T1 Map<T, T1>(T p0)
        {
            return Bootstrap.ObjectMapperPlugin.Map<T, T1>(p0);
        }
    }
}