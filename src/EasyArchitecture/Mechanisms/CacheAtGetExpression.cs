using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class CacheAtGetExpression
    {
        public object At(string key)
        {
            return EasyConfigurations.SelectorByThread().Cache.GetData(key);
        }
    }
}