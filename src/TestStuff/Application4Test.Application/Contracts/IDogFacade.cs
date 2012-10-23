using System.Collections.Generic;
using Application4Test.Application.Contracts.DTOs;

namespace Application4Test.Application.Contracts
{
    public interface IDogFacade
    {
        DogDto GetDog(DogDto dog);
        DogDto CreateDog(DogDto dog);
        void UpdateDog(DogDto dog);
        List<DogDto> GetAllOldDogs(int age);
    }
}
