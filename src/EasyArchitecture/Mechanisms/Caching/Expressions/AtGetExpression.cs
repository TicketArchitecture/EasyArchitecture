using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Caching.Expressions
{
    public class AtGetExpression
    {
        public object At(string key)
        {
            return InstanceProvider.GetInstance<Instances.Caching.Cache>().GetData(key);
        }

        public object At(object key)
        {
            return At(key.ToString());
        }
    }
}