namespace EasyArchitecture.Common
{
    public class InvalidEntityException : DomainException
    {
        public InvalidEntityException(params string[] messages):base(messages)
        {
        }

    }
}
