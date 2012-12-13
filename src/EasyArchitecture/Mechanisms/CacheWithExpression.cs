namespace EasyArchitecture.Mechanisms
{
    public class CacheWithExpression
    {
        private readonly object _item;

        public CacheWithExpression(object item)
        {
            _item = item;
        }

        public CacheAtExpression NoExpiration
        {
            get { return new CacheAtExpression(_item); }
         
        }

        public CacheTimeExpirationExpression ExpirationOf(int value)
        {
            return new CacheTimeExpirationExpression(_item, value);
        }
    }
}