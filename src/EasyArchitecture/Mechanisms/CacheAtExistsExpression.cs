using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class CacheAtExistsExpression
    {
        public bool At(string key)
        {
            return EasyConfigurations.SelectorByThread().Cache.Contains(key);
        }
    }
}