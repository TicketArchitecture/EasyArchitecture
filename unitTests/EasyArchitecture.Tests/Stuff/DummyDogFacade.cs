using System.Collections.Generic;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;

namespace EasyArchitecture.Tests
{
    public class DummyDogFacade : IDogFacade
    {
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

        public List<DogDto> GetAllOldDogs(int age)
        {
            throw new System.NotImplementedException();
        }
    }
}