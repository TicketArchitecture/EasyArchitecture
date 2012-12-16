namespace EasyArchitecture.Runtime.Contracts
{
    internal interface IProviderFactory<T>
    {
        T GetInstance();
    }
}