using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Character;
using Models;

namespace Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;

        }
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1,Name = "Sam" },
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character characterNew = _mapper.Map<Character>(character);
            characterNew.Id = characters.Max(c => c.Id) + 1;
            characters.Add(characterNew);
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character characterNew = characters.FirstOrDefault(c => c.Id == character.Id);
                characterNew.Name = character.Name;
                characterNew.HitPoints = character.HitPoints;
                characterNew.Strength = character.Strength;
                characterNew.Defence = character.Defence;
                characterNew.Intelligence = character.Intelligence;
                characterNew.rpgEnum = character.rpgEnum;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(characterNew);
            }
            catch (System.Exception exp)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = exp.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character characterNew = characters.First(c => c.Id == id);
                characters.Remove(characterNew);
                serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (System.Exception exp)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = exp.Message;
            }
            
            return serviceResponse;
        }
    }
}