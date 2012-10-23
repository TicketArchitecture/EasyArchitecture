using System.Collections.Generic;
using AutoMapper;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using Application4Test.Application.Contracts;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Application.Queriers;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;

namespace Application4Test.Application
{
    public class DogFacade : IDogFacade
    {
        private readonly IDogRepository _repository;

        public DogFacade(IDogRepository repository)
        {
            _repository = repository;
        }


        public virtual DogDto GetDog(DogDto dog)
        {
            var entity = Mapper.Map<DogDto, Dog>(dog);

            entity = _repository.GetDog(entity);

            var dto = Mapper.Map<Dog, DogDto>(entity);

            return dto;
        }

        public virtual DogDto CreateDog(DogDto dog)
        {
            var entity = Mapper.Map<DogDto, Dog>(dog);

            _repository.CreateDog(entity);

            var dto = Mapper.Map<Dog, DogDto>(entity);

            return dto;
        }

        public virtual void UpdateDog(DogDto dog)
        {
            var entity = Mapper.Map<DogDto, Dog>(dog);

            Log.To(this).Message("Teste").Debug();


            var updEntity = _repository.GetDog(entity);
            updEntity.Name = entity.Name;
            updEntity.Age = entity.Age;

            _repository.UpdateDog(updEntity);
        }


        [QueryMethod]
        public virtual List<DogDto> GetAllOldDogs(int age)
        {
            return new DogQuerier().GetAllOldDogs(age);
        }

    }
}
