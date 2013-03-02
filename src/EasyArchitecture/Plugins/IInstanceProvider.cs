namespace EasyArchitecture.Plugins
{
    public interface IInstanceProvider<T>
    {
        T GetInstance();
    }
}