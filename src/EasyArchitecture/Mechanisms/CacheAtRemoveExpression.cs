using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class CacheAtRemoveExpression
    {
        public void At(string key)
        {
            EasyConfigurations.SelectorByThread().Cache.Remove(key);
        }
    }
}