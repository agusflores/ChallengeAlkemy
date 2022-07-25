using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<List<ViewCharacterDTO>> FindCharacters(string name, int? age, int? idSerie);
        Task<List<ViewFullCharacterDTO>> Find();
        Task <Character> CreateCharacter(ViewFullCharacterDTO viewFullCharacterDTO);
        Task<Character> UpdateCharacter(ViewUpdateCharacterDTO viewUpdateCharacterDTO);
        Task<Character> DeleteCharacter(int id);

    }
}
