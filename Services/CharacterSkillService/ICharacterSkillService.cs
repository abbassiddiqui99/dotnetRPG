using System.Threading.Tasks;
using Dtos.Character;
using Dtos.CharacterSkill;
using Models;

namespace Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}