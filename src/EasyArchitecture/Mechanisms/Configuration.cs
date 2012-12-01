namespace EasyArchitecture.Mechanisms
{
    public static class Configuration
    {
        public static ConfigurationExpression For(string businessModule)
        {
            return new ConfigurationExpression(businessModule);
        }
    }
}