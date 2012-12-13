using EasyArchitecture.Configuration.Expressions;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Configuration
{
    public static class Configure
    {
        public static ForExpression For(string moduleName)
        {
            return new ForExpression(moduleName);
        }
        
        public static ForExpression For<T>()
        {
            var moduleName = AssemblyManager.ModuleName<T>();
            return new ForExpression(moduleName);
        }
    }
}