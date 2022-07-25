using ChallengeAlkemy.DTO.Gender;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services.Interfaces
{
    public interface IGenderService
    {
        Task<List<GetGendersDTO>> GetGenders();

    }
}
