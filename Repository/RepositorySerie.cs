using ChallengeAlkemy.DataContext;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository
{
    public class RepositorySerie : IRepositorySerie
    {
        private readonly ApplicationDbContext dbContext;
        public RepositorySerie(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateSerie(Serie serie)
        {
            dbContext.Series.Add(serie);
        }

        public async Task DeleteSerie(Serie serie)
        {
            dbContext.Series.Remove(serie);
        }

        public async Task<List<Serie>> FindSeries()
        {
            return await dbContext.Series
                .Include(s => s.Characters)
                .ThenInclude(c => c.Character)
                .ToListAsync();
        }
        public async Task<List<Serie>> FindSeriesQuery(string title, int? idGender)
        {
            var seriesOrdenadas = dbContext.Series.OrderByDescending(s => s.Title);
            return await dbContext.Series
                .Where(c => (c.Title == title || title == null) &&
                    (c.GenderId == idGender || idGender == null))
                .ToListAsync();
        }

        public async Task<Gender> GetGender(int id)
        {
           var result = await dbContext.Genders.FindAsync(id);
           return result;
        }

        public async Task<Serie> GetSerie(int id)
        {
            var serie = await dbContext.Series.FirstOrDefaultAsync(x => x.Id == id);
            if (serie != null) return serie;
            return null;
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> SerieExists(string title)
        {
            var result = await dbContext.Series.FirstOrDefaultAsync(x => x.Title == title);
            if (result != null) return true;
            return false;
        }
        public async Task UpdateSerie(Serie serie)
        {
            dbContext.Series.Update(serie);
        }
    }
}
