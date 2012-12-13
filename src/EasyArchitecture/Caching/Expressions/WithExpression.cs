namespace EasyArchitecture.Caching.Expressions
{
    public class WithExpression
    {
        private readonly object _item;

        public WithExpression(object item)
        {
            _item = item;
        }

        public AtExpression NoExpiration
        {
            get { return new AtExpression(_item); }
         
        }

        public TimeExpirationExpression ExpirationOf(int value)
        {
            return new TimeExpirationExpression(_item, value);
        }
    }
}