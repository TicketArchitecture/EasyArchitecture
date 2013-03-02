using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Translation;

namespace EasyArchitecture.Plugins.BultIn.Translation
{
    internal class TranslatorPlugin : Plugin, ITranslatorPlugin
    {
        private readonly List<TypeMap> _mappedTypes = new List<TypeMap>();

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var assembly = pluginConfiguration.InfrastructureAssembly;
            foreach (var mapRule in from tipo in assembly.GetExportedTypes()
                                      where tipo.BaseType == typeof(MapRule)
                                      select tipo.Assembly.CreateInstance(tipo.FullName))
            {
                AddMapRule((MapRule) mapRule);
                pluginInspector.Log("Adding MapRule for {0}", mapRule.GetType().Name);
            }
        }

        public ITranslator GetInstance()
        {
            return new Translator(_mappedTypes);
        }

        private void AddMapRule(MapRule mapRule)
        {
            _mappedTypes.AddRange(mapRule.GetMapRules());
        }
    }
}
