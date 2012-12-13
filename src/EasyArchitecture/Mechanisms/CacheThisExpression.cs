namespace EasyArchitecture.Mechanisms
{
    public class CacheThisExpression
    {
        private readonly object _item;

        public CacheThisExpression(object item)
        {
            _item = item;
        }

        public CacheWithExpression With
        {
            get { return new CacheWithExpression(_item); }
        }
    }
}