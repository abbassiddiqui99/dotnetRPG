using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1,Name = "Sam" },
        };
        public List<Character> AddCharacter(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public List<Character> GetAllCharacter()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}