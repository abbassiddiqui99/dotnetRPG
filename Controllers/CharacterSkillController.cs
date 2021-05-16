using System.Threading.Tasks;
using Dtos.Character;
using Dtos.CharacterSkill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.CharacterSkillService;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;
        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = await _characterSkillService.AddCharacterSkill(newCharacterSkill);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}