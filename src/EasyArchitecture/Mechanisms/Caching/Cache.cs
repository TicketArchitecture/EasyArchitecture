using EasyArchitecture.Core;
using EasyArchitecture.Mechanisms.Caching.Expressions;

namespace EasyArchitecture.Mechanisms.Caching
{
    public static class Cache
    {
        public static ThisExpression This(object item)
        {
            return new ThisExpression(item);
        }

        public static AtExistsExpression Exists
        {
            get { return new AtExistsExpression(); }
        }

        public static AtGetExpression Get
        {
            get { return new AtGetExpression(); }
        }

        public static AtRemoveExpression Remove
        {
            get { return new AtRemoveExpression(); }
        }

        public static void Clear()
        {
            InstanceProvider.GetInstance<Instances.Caching.Cache>().Flush();
        }
    }
}

