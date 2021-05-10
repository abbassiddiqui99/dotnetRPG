using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetAllCharacter()
        {
            return Ok(_characterService.GetAllCharacter());
        }
        [HttpGet("{id}")]
        public IActionResult GetCharacterById(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }
        [HttpPost("")]
        public IActionResult AddCharacter(Character character)
        {
            return Ok(_characterService.AddCharacter(character));
        }
    }
}