using EasyArchitecture.Core.Log;
using EasyArchitecture.Plugin.Contracts.IoC;

namespace EasyArchitecture.Instances.IoC
{
    internal class Container
    {
        private readonly IContainer _plugin;

        //TODO: must be internal but i did to activator use
        public Container(IContainer plugin)
        {
            _plugin = plugin;
        }

        internal void Register<T, T1>() where T1 : T
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            _plugin.Register<T, T1>();

            InstanceLogger.Log(this, "Register", typeof(T).Name, typeof(T1).Name);
        }

        internal T Resolve<T>()
        {
            if (!typeof(T).IsInterface)
                throw new NotInterfaceException();

            var ret= _plugin.Resolve<T>();

            InstanceLogger.Log(this, "Resolve", typeof(T).Name, ret.GetType().Name);

            return ret;
        }
    }
}
