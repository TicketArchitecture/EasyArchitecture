using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Plugin.BultIn
{
    internal class TranslatorPlugin : ITranslatorPlugin
    {
        private static readonly List<TypeMap> MappedTypes = new List<TypeMap>();

        public void Configure(Assembly assembly)
        {
            //locate mapped types 

            //load type to MappedTypes
        }
    }
}
