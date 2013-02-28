namespace EasyArchitecture.Mechanisms.Caching.Expressions
{
    public class ThisExpression
    {
        private readonly object _item;

        public ThisExpression(object item)
        {
            _item = item;
        }

        public WithExpression With
        {
            get { return new WithExpression(_item); }
        }
    }
}