using System.Collections.Generic;

namespace EasyArchitecture.Plugin.Contracts.Validation
{
    public interface IValidator
    {
        List<string> Validate<T>(T obj);
    }
}