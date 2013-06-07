namespace EasyArchitecture.Plugins.Contracts.IoC
{
    public interface IContainer
    {
        void Register<T, TU>() where TU : T;
        T Resolve<T>();
    }
}