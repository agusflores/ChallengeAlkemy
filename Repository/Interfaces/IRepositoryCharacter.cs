using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repository.Interfaces
{
    public interface IRepositoryCharacter
    {
        Task<Character> FindCharacterById(int id);
        Task<List<Character>> FindCharacters(string name, int? age, int? series);
        Task CreateCharacter(Character character);
        Task UpdateCharacter(Character character);
        Task DeleteCharacter(Character character);
        Task SaveChanges();
        Task<Serie> FindSerie(int id);
    }
}
