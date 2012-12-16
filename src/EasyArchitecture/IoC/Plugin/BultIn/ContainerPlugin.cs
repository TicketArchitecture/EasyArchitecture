using System;
using System.Reflection;
using EasyArchitecture.IoC.Plugin.Contracts;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class ContainerPlugin : IContainerPlugin
    {
        public void Configure(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public IContainer GetInstance()
        {
            return new Container();
        }
    }

}