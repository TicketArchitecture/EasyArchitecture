using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtGetExpression
    {
        public object At(string key)
        {
            return ConfigurationSelector.SelectorByThread().Cache.GetData(key);
        }
    }
}