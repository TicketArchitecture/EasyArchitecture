using System.Linq;
using AutoMapper;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Translation;

namespace EasyArchitecture.Plugins.AutoMapper
{
    public class AutoMapperPlugin : Plugin,ITranslatorPlugin
    {
        public ITranslator GetInstance()
        {
            return new AutoMapperTranslator();
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var assembly = pluginConfiguration.InfrastructureAssembly;
            pluginInspector.Log("Configuring assembly {0}", assembly.GetName().Name);

            foreach (var instance in assembly.GetExportedTypes().Where(tipo => tipo.BaseType == typeof(Profile)).Select(tipo => (Profile)tipo.Assembly.CreateInstance(tipo.FullName)))
            {
                Mapper.AddProfile(instance);
                pluginInspector.Log("Adding profile instance {0}", instance.GetType());
            }

            Mapper.AssertConfigurationIsValid();

        }
    }
}


