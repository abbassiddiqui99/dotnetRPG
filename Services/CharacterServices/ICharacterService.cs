using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacter();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> AddCharacter(Character character);
    }
}