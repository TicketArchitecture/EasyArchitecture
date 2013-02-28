using EasyArchitecture.Mechanisms.Translation.Expressions;

namespace EasyArchitecture.Mechanisms.Translation
{
    public static class Translator
    {
        public static ToExpression<T> This<T>(T obj)
        {
            return new ToExpression<T>(obj);
        }
    }
}