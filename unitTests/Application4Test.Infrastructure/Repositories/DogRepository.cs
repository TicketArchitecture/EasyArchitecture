using EasyArchitecture.Data;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;

namespace Application4Test.Infrastructure.Repositories
{
    public class DogRepository : NHibernateRepository<Dog>, IDogRepository
    {
        public void CreateDog(Dog dog)
        {
            base.Save(dog);
        }

        public Dog GetDog(Dog dog)
        {
            return base.Get(dog.Id);
        }

        public void UpdateDog(Dog dog)
        {
            base.Update(dog);
        }
    }
}
