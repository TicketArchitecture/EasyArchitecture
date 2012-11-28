using System.Linq;
using System.Reflection;
using AutoMapper;
using EasyArchitecture.Initialization;

namespace EasyArchitecture.Plugins.Automapper
{
    public class AutoMapperPlugin : IObjectMapperPlugin
    {
        public void Configure(Assembly assembly)
        {
            foreach (var tipo in assembly.GetExportedTypes().Where(tipo => tipo.BaseType ==  typeof(Profile)))
            {
                //TODO: try to use baseclass instead interface to provide log 
                //base.Log(...)
                //Log.To(typeof(AutoMapperInitializer)).Message("Initializing [{0}]", tipo.FullName).Debug();

                var instance = (Profile)tipo.Assembly.CreateInstance(tipo.FullName);
                AutoMapper.Mapper.AddProfile(instance);
            }

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        public T1 Map<T, T1>(T p0)
        {
            return AutoMapper.Mapper.Map<T, T1>(p0);
        }
    }
}


