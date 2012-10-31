using FluentNHibernate.Mapping;
using Application4Test.Domain;

namespace Application4Test.Infrastructure.Repositories.Mappings
{
    public class DogMap : ClassMap<Dog>
    {
        public DogMap()
        {
            //Table("Dog");
            Id(dog => dog.Id);
            Map(dog => dog.Age);
            Map(dog => dog.Name);
        }
    }
}
