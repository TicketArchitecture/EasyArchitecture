namespace EasyArchitecture.Runtime
{
    public static class InstanceProvider
    {
        public static T GetInstance<T>() where T : class
        {
            var instance =  LocalThreadStorage.GetInstance<T>();
            if (instance==null)
            {
                instance = FactoryDiscovery.Discover<T>().GetInstance();
                LocalThreadStorage.SetInstance<T>(instance);
            }
            return (T) instance;
        }
    }
}