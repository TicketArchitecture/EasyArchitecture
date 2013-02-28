using EasyArchitecture.Core;
using EasyArchitecture.Core.IO;

namespace EasyArchitecture.Mechanisms.Caching.Expressions
{
    public class AtRemoveExpression
    {
        public void At(string key)
        {
            InstanceProvider.GetInstance<Instances.Caching.Cache>().Remove(key);
        }

        public void At(object key)
        {
            At(SerializationHelper.Mount(key));
        }
    }
}