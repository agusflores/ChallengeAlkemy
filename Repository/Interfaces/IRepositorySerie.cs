using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository.Interfaces
{
    public interface IRepositorySerie
    {
        Task<List<Serie>> FindSeriesQuery(string title, int? idGender);
        Task<List<Serie>> FindSeries();
        Task CreateSerie(Serie serie);
        Task UpdateSerie(Serie serie);
        Task DeleteSerie(Serie serie);
        Task SaveChanges();
        Task<bool> SerieExists(string title);
        Task<Serie> GetSerie(int id);
        Task<Gender> GetGender(int id);
    }
}
