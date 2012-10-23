namespace EasyArchitecture.Domain
{
    public class InvalidEntityException : DomainException
    {
        public InvalidEntityException(params string[] messages):base(messages)
        {
        }

    }
}
