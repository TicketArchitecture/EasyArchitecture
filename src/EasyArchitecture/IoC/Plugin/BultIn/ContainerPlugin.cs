using System;
using System.Reflection;
using EasyArchitecture.Configuration.Instance;
using EasyArchitecture.IoC.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class ContainerPlugin : IContainerPlugin
    {
        public void Configure(ModuleAssemblies moduleAssemblies)
        {
            throw new NotImplementedException();
        }

        public IContainer GetInstance()
        {
            return new Container();
        }
    }

}