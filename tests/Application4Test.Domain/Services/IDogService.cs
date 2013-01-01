using System.Collections.Generic;

namespace Application4Test.Domain.Services
{
    public interface IDogService
    {
        Dog GetOlderDog(IList<Dog> dogs);

        void PutDogToSleep(Dog dog);
    }
}
