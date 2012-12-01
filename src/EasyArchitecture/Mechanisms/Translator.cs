namespace EasyArchitecture.Mechanisms
{
    public static class Translator
    {
        public static TranslatorToExpression<T> This<T>(T obj)
        {
            return new TranslatorToExpression<T>(obj);
        }
    }
}