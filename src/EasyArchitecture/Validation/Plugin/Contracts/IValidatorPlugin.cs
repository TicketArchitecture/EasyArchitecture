using System;
using System.Reflection;

namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public interface IValidatorPlugin
    {
        void Configure(Assembly assembly);
        IValidatorInstance GetInstance();
    }
}