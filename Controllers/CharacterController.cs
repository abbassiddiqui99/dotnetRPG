using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Character;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.CharacterServices;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCharacter()
        {
            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost("")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto character)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(character);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}