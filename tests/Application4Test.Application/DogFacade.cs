using System.Collections.Generic;
using Application4Test.Application.Queries;
using EasyArchitecture.Common;
using EasyArchitecture.Common.Persistence;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Mechanisms;

namespace Application4Test.Application
{
    public class DogFacade : IDogFacade
    {
        private readonly IDogRepository _dogRepository;

        public DogFacade(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public DogDto GetDog(DogDto dog)
        {
            var entity = _dogRepository.Get(dog.Id);
            var dto = Translator.This(entity).To<DogDto>();

            return dto;
        }

        public DogDto CreateDog(DogDto dog)
        {
            var entity = Translator.This(dog).To<Dog>();

            _dogRepository.Save(entity);

            var dto = Translator.This(entity).To<DogDto>();

            return dto;
        }

        public void UpdateDog(DogDto dto)
        {
            Logger.Message("Teste").Debug();

            var entity = _dogRepository.Get(dto.Id);

            Translator.This(dto).To(entity);

            _dogRepository.Update(entity);
        }

        //TODO: mount by reflection
        [QueryMethod]
        public IList<DogDto> GetAllOldDogs(int age)
        {
            return Querier.Execute(new GetAgedDogs(age));
        }

        [QueryMethod]
        public IList<DogDto> GetAllDogs()
        {
            return Querier.Execute(new GetAllDogs());
        }
    }
}
