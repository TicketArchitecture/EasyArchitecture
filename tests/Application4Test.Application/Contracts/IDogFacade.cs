using System.Collections.Generic;
using Application4Test.Application.Contracts.DTOs;

namespace Application4Test.Application.Contracts
{
    public interface IDogFacade
    {
        IList<DogDto> GetDogs(DogDto dog);
        DogDto GetDog(int dog);
        DogDto CreateDog(DogDto dog);
        void UpdateDog(DogDto dog);
        //IList<DogDto> GetAllOldDogs(int age);
        //IList<DogDto> GetAllDogs();
        void PutDogToSleep(DogDto dog);
    }
}
