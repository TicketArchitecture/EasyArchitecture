using Application4Test.Application.Contracts.DTOs;
using Application4Test.Domain;
using AutoMapper;


namespace Application4Test.Infrastructure.ObjectMapper
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
