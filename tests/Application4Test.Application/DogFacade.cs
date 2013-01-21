using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using Application4Test.Domain.Services;
using EasyArchitecture.Caching;
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

        public DogDto GetDog(int id)
        {
            Contract.Requires(id > 0);

            if(Cache.Exists.At(id.ToString()))
            {
                return (DogDto)Cache.Get.At(id.ToString());
            }

            var entity = _dogRepository.Get(id);
            var dto = Translator.This(entity).To<DogDto>();

            Cache.This(dto).With.NoExpiration.At(id.ToString());

            return dto;
        }

        public DogDto CreateDog(DogDto dog)
        {
            Contract.Requires(dog != null);

            var entity = Translator.This(dog).To<Dog>();

            _dogRepository.Save(entity);

            var dto = Translator.This(entity).To<DogDto>();

            Cache.This(dto).With.NoExpiration.At(dto.Id.ToString());

            return dto;
        }

        //TODO: change return type to void, because bug has fixed
        public int UpdateDog(DogDto dog)
        {
            Contract.Requires(dog != null);

            Logger.Message("Teste").Debug();

            var entity = _dogRepository.Get((int)dog.Id);

            Translator.This(dog).To(entity);

            _dogRepository.Update(entity);

            //if (!Cache.Exists.At(dog.Id.ToString()))
            //{
                Cache.This(dog).With.NoExpiration.At(dog.Id.ToString());
            //}

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

            //TODO: clean -> remove spaces


        }


        public IList<DogDto> GetDogs(DogDto qbeDog)
        {
            //TODO: ligar contract
            Contract.Requires(qbeDog != null);

            if(Cache.Exists.At(qbeDog))
            {
                return (IList<DogDto>) Cache.Get.At(qbeDog);
            }

            var dogEntity = Translator.This(qbeDog).To<Dog>();
            var entityLst = _dogRepository.Get(dogEntity);
            var dtoLst = Translator.This(entityLst).To<IList<DogDto>>();

            Cache.This(dtoLst).With.NoExpiration.At(qbeDog);

            return dtoLst;
        }
        
    }

    
}
