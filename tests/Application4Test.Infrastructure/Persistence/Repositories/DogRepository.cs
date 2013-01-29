using System.Linq;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Persistence;

namespace Application4Test.Infrastructure.Persistence.Repositories
{
    public class DogRepository : Repository<Dog>, IDogRepository
    {
        public Dog Get(int id)
        {
            var qbe = new Dog() {Id = id};
            return base.Get(qbe).FirstOrDefault();
        }
    }
}