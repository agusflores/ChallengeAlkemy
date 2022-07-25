using ChallengeAlkemy.DataContext;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository
{
    public class RepositoryGender : IRepositoryGender
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryGender(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Gender>> GetGenders()
        {
            return await _dbContext.Genders
                .Include(s => s.Series)
                .ToListAsync();
        }
    }
}
