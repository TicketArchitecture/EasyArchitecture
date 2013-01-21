using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.IO;

namespace EasyArchitecture.Caching.Expressions
{
    public class AtRemoveExpression
    {
        public void At(string key)
        {
            InstanceProvider.GetInstance<Instance.Cache>().Remove(key);
        }

        public void At(object key)
        {
            At(SerializationHelper.Mount(key));
        }
    }
}