using ChallengeAlkemy.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository.Interfaces
{
    public interface IRepositoryGender
    {
        Task<List<Gender>> GetGenders(); 
    }
}
