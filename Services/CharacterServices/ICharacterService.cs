using System.Collections.Generic;
using Models;

namespace Services.CharacterServices
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacter();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character character);
    }
}