using EasyArchitecture.Validation.Expressions;

namespace EasyArchitecture.Validation
{
    public static class Validator
    {
        public static ThisExpression<T> This<T>(T obj)
        {
            return new ThisExpression<T>(obj);
        }
    }
}
