namespace EasyArchitecture.Mechanisms
{
    public class Translator
    {
        public static TranslatorToExpression<T> This<T>(T obj)
        {
            return new TranslatorToExpression<T>(obj);
        }
    }
}