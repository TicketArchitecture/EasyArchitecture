using EasyArchitecture.Runtime;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtExistsExpression
    {
        public bool At(string key)
        {
            return InstanceProvider.GetInstance<Instance.Cache>().Contains(key);
        }
    }
}