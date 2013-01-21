using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.IO;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtGetExpression
    {
        public object At(string key)
        {
            return InstanceProvider.GetInstance<Instance.Cache>().GetData(key);
        }

        public object At(object key)
        {
            return At(SerializationHelper.Mount(key));
        }

    }
}