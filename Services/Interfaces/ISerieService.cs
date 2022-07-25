using ChallengeAlkemy.DTO.Series;
using ChallengeAlkemy.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services.Interfaces
{
    public interface ISerieService
    {
        Task<List<ViewSerieDTO>> FindSeries();
        Task<List<ViewFullSerieDTO>> Find();
        Task<Serie> CreateSerie(CreateSerieDTO createSerieDTO); 
        Task<Serie> UpdateSerie(UpdateSerieDTO updateSerieDTO);
        Task<List<ViewSerieDTO>> FindSeriesByQuery(string title, int? idGender);
        Task<Serie> DeleteSerie(int id);

    }
}
