using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Character;
using Dtos.Weapon;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public WeaponService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;

        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _dataContext.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && 
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }
                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                await _dataContext.Weapons.AddAsync(weapon);
                await _dataContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}