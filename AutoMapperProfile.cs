using AutoMapper;
using Dtos.Character;
using Models;

namespace dotnet_rpg_new
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();

        }
    }
}