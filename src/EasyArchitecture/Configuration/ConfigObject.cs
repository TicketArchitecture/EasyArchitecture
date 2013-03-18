using System;
using EasyArchitecture.Core;

namespace EasyArchitecture.Configuration
{
    public class ConfigObject
    {
        private readonly string _moduleName;

        public ConfigObject(string moduleName)
        {
            _moduleName = moduleName;
        }

        public T ActivateFacade<T>()
        {
            ActivateCurrentThread();
            return InstanceProvider.GetInstance<Instances.IoC.Container>().Resolve<T>();
        }

        //public object ActivateFacade(Type type)
        //{
        //    ActivateCurrentThread();
        //    return InstanceProvider.GetInstance<Instances.IoC.Container>().Resolve(type);
        //}


        public void ActivateCurrentThread()
        {
            ThreadContext.Create(_moduleName);
        }
    }
}