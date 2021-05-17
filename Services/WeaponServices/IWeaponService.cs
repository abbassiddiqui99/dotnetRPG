using System.Threading.Tasks;
using Dtos.Character;
using Dtos.Weapon;
using Models;

namespace Services.WeaponServices
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}