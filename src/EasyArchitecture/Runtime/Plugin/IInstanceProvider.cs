namespace EasyArchitecture.Runtime.Plugin
{
    public interface IInstanceProvider<T>
    {
        T GetInstance();
    }
}