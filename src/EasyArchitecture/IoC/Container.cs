using EasyArchitecture.Runtime;

namespace EasyArchitecture.IoC
{
    public static class Container
    {
        public static void Register<T, T1>() where T1 : T
        {
            InstanceProvider.GetInstance<Instance.Container>().Register<T, T1>();
        }
        public static T Resolve<T>()
        {
            //TODO: eh o unico caso pois via container q a facade eh inicializada
            //descobrir o module name para T
            //var modName = AssemblyManager.ModuleName<T>();
            //LocalThreadStorage.SetCurrentModuleName(modName);
            LocalThreadStorage.SetCurrentModuleName(typeof(T));

            return InstanceProvider.GetInstance<Instance.Container>().Resolve<T>();
        }

    }
}