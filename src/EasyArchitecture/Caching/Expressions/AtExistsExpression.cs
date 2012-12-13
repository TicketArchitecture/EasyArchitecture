using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtExistsExpression
    {
        public bool At(string key)
        {
            return EasyConfigurations.SelectorByThread().Cache.Contains(key);
        }
    }
}