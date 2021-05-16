using AutoMapper;
using Dtos.Character;
using Dtos.Weapon;
using Models;

namespace dotnet_rpg_new
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon,GetWeaponDto>();
        }
    }
}