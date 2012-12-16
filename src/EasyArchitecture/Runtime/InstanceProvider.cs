using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Runtime
{
    public static class InstanceProvider
    {
        public static T GetInstance<T>()
        {
            object instance = null;

            //locate at thread
            //var instance = ThreadStorage.GetInstance<T>();

            if (instance==null)
            {
                instance = FactoryDiscovery.Discover<T>().GetInstance();
                //put at thread
                //ThreadStorage.SaveInstance<T>(instance);

            }

            return (T) instance;
        }
    }
}