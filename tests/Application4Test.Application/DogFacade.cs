using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using Application4Test.Domain.Services;
using EasyArchitecture.Log;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Translation;

namespace Application4Test.Application
{
    public class DogFacade : IDogFacade
    {
        private readonly IDogRepository _dogRepository;

        private readonly IDogService _dogService;

        public DogFacade(IDogRepository dogRepository, IDogService dogService)
        {
            _dogRepository = dogRepository;
            _dogService = dogService;
        }

        public DogDto GetDog(DogDto dog)
        {
            Contract.Requires(dog != null);

            var entity = _dogRepository.Get((int) dog.Id);
            var dto = Translator.This(entity).To<DogDto>();

            return dto;
        }

        public DogDto CreateDog(DogDto dog)
        {
            Contract.Requires(dog != null);

            var entity = Translator.This(dog).To<Dog>();

            _dogRepository.Save(entity);

            var dto = Translator.This(entity).To<DogDto>();

            return dto;
        }

        public int UpdateDog(DogDto dog)
        {
            Contract.Requires(dog != null);

            Logger.Message("Teste").Debug();

            var entity = _dogRepository.Get((int)dog.Id);

            Translator.This(dog).To(entity);

            _dogRepository.Update(entity);

            return 0;
        }

        ////TODO: mount by reflection
        //[QueryMethod]
        //public IList<DogDto> GetAllOldDogs(int age)
        //{
        //    Contract.Requires(age >0);

        //    return PersistenceQuerier.Execute<DogDto>("GetAgedDogs",age);
        //}

        //[QueryMethod]
        //public IList<DogDto> GetAllDogs()
        //{
        //    return PersistenceQuerier.Execute<DogDto>("GetAllDogs");
        //}


        public void PutDogToSleep(DogDto dog)
        {

            var entity = Translator.This<DogDto>(dog).To<Dog>();
            _dogService.PutDogToSleep(entity);

            


        }
    }

    
}
