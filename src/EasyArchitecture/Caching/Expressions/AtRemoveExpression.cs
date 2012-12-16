using EasyArchitecture.Runtime;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtRemoveExpression
    {
        public void At(string key)
        {
            InstanceProvider.GetInstance<Instance.Cache>().Remove(key);
        }
    }
}