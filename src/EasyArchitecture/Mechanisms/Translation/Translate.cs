using EasyArchitecture.Mechanisms.Translation.Expressions;

namespace EasyArchitecture.Mechanisms.Translation
{
    public static class Translate
    {
        public static ToExpression<T> This<T>(T obj)
        {
            return new ToExpression<T>(obj);
        }
    }
}