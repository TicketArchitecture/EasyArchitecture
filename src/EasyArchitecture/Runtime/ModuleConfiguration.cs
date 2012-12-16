using System;
using System.Collections.Generic;

namespace EasyArchitecture.Runtime
{
    public class ModuleConfiguration
    {
        public string ModuleName;
        public Dictionary<Type, object> Factories = new Dictionary<Type, object>();
    }
}