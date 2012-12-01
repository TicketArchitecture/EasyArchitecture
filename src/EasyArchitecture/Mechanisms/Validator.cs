namespace EasyArchitecture.Mechanisms
{
    public static class Validator
    {
        public static ValidatorExpression<T> This<T>(T obj)
        {
            return new ValidatorExpression<T>(obj);
        }
    }
}
