using ChallengeAlkemy.DTO.Series;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SerieController : ControllerBase
    {
        private readonly ISerieService _serieService;
        public SerieController(ISerieService serieService)
        {
            this._serieService = serieService;
        }

        [HttpGet]
        [Route("series")]
        public async Task<IActionResult> FindSeries()
        {
            return Ok(await _serieService.FindSeries());
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            return Ok(await _serieService.Find());
        }
        
        [HttpGet]
        [Route("seriesConsulta")]
        public async Task<IActionResult> FindSeriesByQuery([FromQuery]string title,[FromQuery] int? idGender)
        {
            return Ok(await _serieService.FindSeriesByQuery(title, idGender));
        }


        [HttpPost]
        public async Task<IActionResult> CreateSerie(CreateSerieDTO createSerieDTO)
        {
            var result = await _serieService.CreateSerie(createSerieDTO);
            if (result == null)
            {
                BadRequest("Ocurrio un error al intentar crear la serie!!");
            }
            return Ok("Serie creada correctamente!!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSerie(UpdateSerieDTO updateSerieDTO) 
        {
            var result = await _serieService.UpdateSerie(updateSerieDTO);
            if (result == null)
            {
                BadRequest("Ocurrio un error al intentar actualizar la serie!!");
            }
            return Ok("Serie actualizada correctamente!!");
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteSerie(int Id)
        {
            var result = await _serieService.DeleteSerie(Id);
            if (result == null)
            {
                BadRequest("Ocurrio un error al intentar borrar la serie!!");
            }
            return Ok("Serie borrada correctamente!!");
        }
    }
}
