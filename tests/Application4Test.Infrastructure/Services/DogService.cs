using System.Collections.Generic;
using System.Linq;
using Application4Test.Domain;
using Application4Test.Infrastructure.Persistence.Repositories;
using Application4Test.Domain.Services;

namespace Application4Test.Infrastructure.Services
{
    public class DogService : IDogService
    {
        public Dog GetOlderDog(IList<Dog> dogs)
        {
            var olderAge = dogs.Select(i => i.Age).Max();
            return dogs.FirstOrDefault(d => d.Age == olderAge);
        }


        public void PutDogToSleep(Dog dog)
        {
            dog.IsSleeping = true;

            var repo = new DogRepository();
            repo.Update(dog);
        }
    }
}
