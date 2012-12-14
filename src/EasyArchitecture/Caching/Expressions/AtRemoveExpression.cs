using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtRemoveExpression
    {
        public void At(string key)
        {
            ConfigurationSelector.SelectorByThread().Cache.Remove(key);
        }
    }
}