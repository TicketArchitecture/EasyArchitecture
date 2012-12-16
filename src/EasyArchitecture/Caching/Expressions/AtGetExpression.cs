using EasyArchitecture.Runtime;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtGetExpression
    {
        public object At(string key)
        {
            return InstanceProvider.GetInstance<Instance.Cache>().GetData(key);
        }
    }
}