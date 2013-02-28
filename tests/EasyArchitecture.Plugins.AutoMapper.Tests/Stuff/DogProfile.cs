using AutoMapper;
using EasyArchitecture.Plugins.Validation.Translation.Stuff;

namespace EasyArchitecture.Plugins.AutoMapper.Tests.Stuff
{
    public class DogProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Cat, CatDto>();
            Mapper.CreateMap<Cat, AnotherCatDto>()
                .ForMember(d => d.Alias, o => o.Ignore());
            Mapper.CreateMap<Cat, OtherCatDto>()
                .ForMember(d => d.Age, o => o.MapFrom(m=>m.Age+1))
                .ForMember(d => d.Name, o => o.MapFrom(m=>"NewName"));

            Mapper.CreateMap<Holder, HolderDto>();
        }
    }
}