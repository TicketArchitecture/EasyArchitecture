using System.Linq;
using System.Reflection;
using AutoMapper;
using EasyArchitecture.Diagnostic;

namespace EasyArchitecture.Initialization
{
    internal static class AutoMapperInitializer
    {
        internal static void Configure(Assembly assembly)
        {
            foreach (var tipo in assembly.GetExportedTypes().Where(tipo => tipo.BaseType ==  typeof(Profile)))
            {
                Log.To(typeof(AutoMapperInitializer)).Message("Initializing [{0}]", tipo.FullName).Debug();

                var instance = (Profile)tipo.Assembly.CreateInstance(tipo.FullName);
                Mapper.AddProfile(instance);
            }

            Mapper.AssertConfigurationIsValid();
        }
    }
}


