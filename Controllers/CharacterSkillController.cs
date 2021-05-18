using System.Threading.Tasks;
using Dtos.CharacterSkill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill){
            return Ok(await _characterSkillService.AddCharacterSkill(newCharacterSkill));
        }
    }
}