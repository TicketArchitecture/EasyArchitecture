using System.Collections.Generic;
using System.Reflection;

namespace EasyArchitecture.Plugins
{
    public interface IValidatorPlugin
    {
        void Configure(Assembly assembly);
        List<string> Validate<T>(T entity);
    }
}