namespace EasyArchitecture.Core
{
    public static class InstanceProvider
    {
        public static T GetInstance<T>() where T : class
        {
            var instance = LocalThreadStorage.GetCurrentContext().GetInstance<T>();
            if (instance == null)
            {
                instance = FactoryDiscovery.Discover<T>().GetInstance();
                LocalThreadStorage.GetCurrentContext().SetInstance<T>(instance);
            }
            return (T)instance;
        }

        public static T GetLocalInstance<T>() where T : class
        {
            var instance = LocalThreadStorage.GetCurrentContext().GetInstance<T>();
            return (T)instance;
        }
    }
}