namespace EasyArchitecture.Validation.Instance
{
    public class InvalidEntityException : DomainException
    {
        public InvalidEntityException(params string[] messages):base(messages)
        {
        }
    }
}
