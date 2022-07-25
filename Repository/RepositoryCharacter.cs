using ChallengeAlkemy.DataContext;
using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using ChallengeAlkemy.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository
{
    public class RepositoryCharacter : IRepositoryCharacter
    {
        private readonly ApplicationDbContext dbContext;
        public RepositoryCharacter(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateCharacter(Character character)
        {
            await dbContext.AddAsync(character);
        }

        public async Task DeleteCharacter(Character character)
        {
            dbContext.Remove(character);
        }
        public async Task<Character> FindCharacterById(int id)
        {
            var result = await dbContext.Characters.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<Character>> FindCharacters(string name, int? age, int? series)
        {
           return await dbContext.Characters
                .Where(c => (c.Name == name || name == null) && 
                    (c.Age == age || age == null) && 
                    (series == null || c.Series.Any(s => s.SerieId == series)))
                .ToListAsync();
        }

        public async Task<Serie> FindSerie(int id)
        {
            var result = await dbContext.Series.FindAsync(id);
            return result; 
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync(); 
        }

        public async Task UpdateCharacter(Character character)
        {
            dbContext.Characters.Update(character);
        }
    }
}
