using AutoMapper;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;

namespace Application4Test.Application.Profiles
{
    public class DogProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Dog, DogDto>();
            Mapper.CreateMap<DogDto, Dog>();
        }
    }
}
