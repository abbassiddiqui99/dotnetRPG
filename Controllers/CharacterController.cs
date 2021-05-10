using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public static Character knight = new Character();
        public IActionResult Get(){
            return Ok(knight);
        }
    }
}