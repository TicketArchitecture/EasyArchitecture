using System.Collections.Generic;
using EasyArchitecture.Runtime;
using EasyArchitecture.Translation.Plugin.Contracts;

namespace EasyArchitecture.Translation.Plugin.BultIn
{
    internal class TranslatorPlugin : ITranslatorPlugin
    {
        private readonly List<TypeMap> MappedTypes = new List<TypeMap>();


        public ITranslator GetInstance()
        {
            return new Translator(MappedTypes);
        }

        public void Configure(ModuleAssemblies moduleAssemblies)
        {
                
        }
    }
}
