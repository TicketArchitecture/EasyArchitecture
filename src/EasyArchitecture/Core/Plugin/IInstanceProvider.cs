namespace EasyArchitecture.Core.Plugin
{
    public interface IInstanceProvider<T>
    {
        T GetInstance();
    }
}