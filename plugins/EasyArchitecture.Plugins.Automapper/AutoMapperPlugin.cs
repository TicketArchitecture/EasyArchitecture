using System.Linq;
using System.Reflection;
using AutoMapper;

namespace EasyArchitecture.Plugins.Automapper
{
    public class AutoMapperPlugin : IObjectMapperPlugin
    {
        public void Configure(Assembly assembly)
        {
            foreach (var instance in assembly.GetExportedTypes().Where(tipo => tipo.BaseType ==  typeof(Profile)).Select(tipo => (Profile)tipo.Assembly.CreateInstance(tipo.FullName)))
            {
                Mapper.AddProfile(instance);
            }

            Mapper.AssertConfigurationIsValid();
        }

        public T1 Map<T, T1>(T p0)
        {
            return Mapper.Map<T, T1>(p0);
        }

        public T1 Map<T, T1>(T p0, T1 obj1)
        {
            return Mapper.Map<T, T1>(p0,obj1);
        }
    }
}


