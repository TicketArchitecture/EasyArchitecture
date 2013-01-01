using System.Collections.Generic;
using Application4Test.Application.Contracts.DTOs;

namespace Application4Test.Application.Contracts
{
    public interface IDogFacade
    {
        DogDto GetDog(DogDto dog);
        DogDto CreateDog(DogDto dog);
        int UpdateDog(DogDto dog);
        //IList<DogDto> GetAllOldDogs(int age);
        //IList<DogDto> GetAllDogs();
        void PutDogToSleep(DogDto dog);
    }
}
