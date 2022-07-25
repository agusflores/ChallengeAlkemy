using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService _personajeService)
        {
            this._characterService = _personajeService;
        }

        [HttpGet]
        [Route("characters")]
        public async Task<IActionResult> FindCharacters([FromQuery] string name, [FromQuery] int? age, [FromQuery] int? idSerie)
        {
            return Ok(await _characterService.FindCharacters(name, age, idSerie));
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            return Ok(await _characterService.Find());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter(ViewFullCharacterDTO viewFullCharacterDTO)
        {
            var result = await _characterService.CreateCharacter(viewFullCharacterDTO);
            if (result == null)
            {
                return BadRequest("Ocurrio un error al crear el personaje!!");
            }
            return Ok("Personaje creado correctamente!!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(ViewUpdateCharacterDTO viewUpdateCharacterDTO)
        {
            var result = await _characterService.UpdateCharacter(viewUpdateCharacterDTO);
            if (result == null)
            {
                return BadRequest("Ocurrio un error al actualizar el personaje!!");
            }
            return Ok($"Personaje actualizado correctamente correctamente!!");
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteCharacter(int Id)
        {
            var result = await _characterService.DeleteCharacter(Id);
            if (result == null)
            {
                return BadRequest("Ocurrio un error al eliminar el personaje!!");
            }
            return Ok($"Personaje borrado correctamente!!");
        }    
    }
}
