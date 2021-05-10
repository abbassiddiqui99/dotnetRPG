using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1,Name = "Sam" },
        };
        public async Task<List<Character>> AddCharacter(Character character)
        {
            characters.Add(character);
            return characters;
        }

        public async Task<List<Character>> GetAllCharacter()
        {
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}