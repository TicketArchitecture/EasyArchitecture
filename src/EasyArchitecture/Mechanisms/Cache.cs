using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public static class Cache
    {
        public static CacheThisExpression This(object item)
        {
            return new CacheThisExpression(item);
        }

        public static CacheAtExistsExpression Exists
        {
            get { return new CacheAtExistsExpression(); }
        }

        public static CacheAtGetExpression Get
        {
            get { return new CacheAtGetExpression(); }
        }

        public static CacheAtRemoveExpression Remove
        {
            get { return new CacheAtRemoveExpression(); }
        }

        public static void Clear()
        {
            EasyConfigurations.SelectorByThread().Cache.Flush();
        }
    }
}

