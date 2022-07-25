using ChallengeAlkemy.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models.ModelsMTM
{
    public class CharacterSerie
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
