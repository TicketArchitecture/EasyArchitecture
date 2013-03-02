using System.Collections.Generic;

namespace EasyArchitecture.Plugins.Contracts.Validation
{
    public interface IValidator
    {
        List<string> Validate<T>(T obj);
    }
}