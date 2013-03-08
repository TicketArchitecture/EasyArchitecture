using EasyArchitecture.Plugins.Tests.Persistence.Stuff;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace EasyArchitecture.Plugins.NHibernate.Tests.Stuff.Code.Mappings
{
    public class DogMap : ClassMapping<Dog>
    {
        public DogMap()
        {
            Table("Dog");
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Name);
            Property(x => x.Age);
        }
    }
}