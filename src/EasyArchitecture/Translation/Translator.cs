using EasyArchitecture.Translation.Expressions;

namespace EasyArchitecture.Translation
{
    public static class Translator
    {
        public static ToExpression<T> This<T>(T obj)
        {
            return new ToExpression<T>(obj);
        }
    }
}