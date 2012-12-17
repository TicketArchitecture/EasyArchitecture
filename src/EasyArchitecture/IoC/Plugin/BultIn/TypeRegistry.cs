using System;

namespace EasyArchitecture.IoC.Plugin.BultIn
{
    internal class TypeRegistry
    {
        internal Type Type;
        internal bool IsInteceptable;

        public TypeRegistry(Type implementationType, bool useInterception)
        {
            Type = implementationType;
            IsInteceptable = useInterception;
        }
    }
}