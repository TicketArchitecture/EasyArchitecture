using System.Data.Entity.ModelConfiguration;
using EasyArchitecture.Plugins.Validation.Persistence.Stuff;

namespace EasyArchitecture.Plugins.EntityFramework.Tests.Stuff.Mappings
{
    public class DogMapping : EntityTypeConfiguration<Dog>
    {
        public DogMapping()
        {
            ToTable("Dog");
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Age);
        }
    }
}