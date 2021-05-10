using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        // public static Character knight = new Character();
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Name = "Sam" },
        };
        public IActionResult Get(){
            return Ok(characters);
        }
        [HttpGet("getfirst")]
        public IActionResult GetFirstCharacter(){
            return Ok(characters[0]);
        }
    }
}