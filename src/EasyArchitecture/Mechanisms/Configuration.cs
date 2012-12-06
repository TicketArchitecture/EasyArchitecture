using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class Configure
    {
        public static ConfigurationExpression For(string moduleName)
        {
            return new ConfigurationExpression(moduleName);
        }
        
        public static ConfigurationExpression For<T>()
        {
            var moduleName = AssemblyManager.ModuleName<T>();
            return new ConfigurationExpression(moduleName);
        }
    }
}