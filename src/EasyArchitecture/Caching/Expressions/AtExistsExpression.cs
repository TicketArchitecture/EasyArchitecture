using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.IO;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtExistsExpression
    {
        public bool At(string key)
        {
            return InstanceProvider.GetInstance<Instance.Cache>().Contains(key);
        }

        public bool At(object key)
        {
            return At(SerializationHelper.Mount(key));
        }
    }
}