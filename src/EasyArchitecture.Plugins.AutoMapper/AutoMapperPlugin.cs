using System.Linq;
using AutoMapper;
using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.Translation;

namespace EasyArchitecture.Plugins.AutoMapper
{
    public class AutoMapperPlugin : AbstractPlugin,ITranslatorPlugin
    {
        public ITranslator GetInstance()
        {
            return new AutoMapperTranslator();
        }

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            var assembly = moduleAssemblies.InfrastructureAssembly;
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


