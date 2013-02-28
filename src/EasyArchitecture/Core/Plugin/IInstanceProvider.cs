namespace EasyArchitecture.Core.Plugin
{
    public interface IInstanceProvider<out T>
    {
        T GetInstance();
    }
}