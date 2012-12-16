using System.Collections.Generic;

namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public interface IValidator
    {
        List<string> Validate<T>(T obj);
    }
}