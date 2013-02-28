namespace EasyArchitecture.Core.Contracts
{
    internal interface IProviderFactory<T>
    {
        T GetInstance();
    }
}