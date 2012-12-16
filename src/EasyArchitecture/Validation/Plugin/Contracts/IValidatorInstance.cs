using System.Collections.Generic;

namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public interface IValidatorInstance
    {
        List<string> Validate<T>(T obj);
    }
}