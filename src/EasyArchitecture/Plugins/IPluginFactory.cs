namespace EasyArchitecture.Plugins
{
    public interface IPluginFactory<out T>
    {
        T GetInstance();
    }
}