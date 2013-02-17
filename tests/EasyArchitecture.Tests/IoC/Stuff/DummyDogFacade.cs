using System.Collections.Generic;

namespace EasyArchitecture.Tests.IoC.Stuff
{
    public class DummyDogFacade : IDogFacade
    {
        public IList<DogDto> GetDogs(DogDto dog)
        {
            List<DogDto> dogs = new List<DogDto>();

            dogs.Add(new DogDto(){Name = "DummyDog"});

            return dogs;
        }

        public DogDto GetDog(DogDto dog)
        {
            throw new System.NotImplementedException();
        }

        public DogDto CreateDog(DogDto dog)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDog(DogDto dog)
        {
            throw new System.NotImplementedException();
        }

        public IList<DogDto> GetAllOldDogs(int age)
        {
            throw new System.NotImplementedException();
        }

        public IList<DogDto> GetAllDogs()
        {
            throw new System.NotImplementedException();
        }


        public void PutDogToSleep(DogDto dog)
        {
            throw new System.NotImplementedException();
        }


        public DogDto GetDog(int dog)
        {
            throw new System.NotImplementedException();
        }

    }
}