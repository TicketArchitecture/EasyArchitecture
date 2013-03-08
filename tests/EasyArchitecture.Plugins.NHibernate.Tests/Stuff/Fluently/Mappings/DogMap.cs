using EasyArchitecture.Plugins.Tests.Persistence.Stuff;
using FluentNHibernate.Mapping;

namespace EasyArchitecture.Plugins.NHibernate.Tests.Stuff.Fluently.Mappings
{
    public class DogMap : ClassMap<Dog>
    {
        public DogMap()
        {
            Table("Dog");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Age);
        }
    }
}
