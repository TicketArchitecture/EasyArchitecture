using EasyArchitecture.Core;
using EasyArchitecture.Core.Log;

namespace EasyArchitecture.Mechanisms.Caching.Expressions
{
    public class AtExistsExpression
    {
        public bool At(string key)
        {
            return InstanceProvider.GetInstance<Instances.Caching.Cache>().Contains(key);
        }

        public bool At(object key)
        {
            return At(SerializationHelper.Mount(key));
        }
    }
}