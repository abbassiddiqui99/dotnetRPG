using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacter();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character character);
    }
}