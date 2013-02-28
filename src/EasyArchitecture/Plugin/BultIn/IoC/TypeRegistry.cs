using System;

namespace EasyArchitecture.Plugin.BultIn.IoC
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