using System.Collections.Generic;
using System.Reflection;

namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public interface IValidatorPlugin
    {
        void Configure(Assembly assembly);
        List<string> Validate<T>(T obj);
    }
}