using System.Collections.Generic;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;

namespace EasyArchitecture.Tests.Stuff
{
    public class DummyDogFacade : IDogFacade
    {
        public DogDto GetDog(DogDto dog)
        {
            return new DogDto(){Name = "DummyDog"};
        }

        public DogDto CreateDog(DogDto dog)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateDog(DogDto dog)
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
    }
}