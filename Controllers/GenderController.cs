using ChallengeAlkemy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenderController : ControllerBase
    {
        private readonly IGenderService genderService;
        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        [HttpGet]
        [Route("/genders")]

        public async Task<IActionResult> GetListGenders()
        {
            var result = await genderService.GetGenders();
            if (result == null)
            {
                return BadRequest("Ocurrio un error al intentar visualizar la lista de generos!!");
            }
            return Ok(result);
        }



    }
}
