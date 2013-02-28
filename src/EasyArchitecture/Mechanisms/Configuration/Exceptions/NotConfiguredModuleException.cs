using System;

namespace EasyArchitecture.Mechanisms.Configuration.Exceptions
{
    public class NotConfiguredModuleException : Exception
    {
        public string ModuleName { get; private set; }

        public NotConfiguredModuleException(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}