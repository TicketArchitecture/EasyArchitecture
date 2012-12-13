namespace EasyArchitecture.Validation.Plugin.Contracts
{
    public class InvalidEntityException : DomainException
    {
        public InvalidEntityException(params string[] messages):base(messages)
        {
        }

    }
}
