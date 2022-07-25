using ChallengeAlkemy.Models;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;

namespace ChallengeAlkemy.DTO.Characters
{
    public class ViewCharacterDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }

        public ViewCharacterDTO(Character c)
        {
            Image = c.Image;
            Name = c.Name;
        }
        public ViewCharacterDTO() { }
    }

    public class ViewCharactersInSerieDTO
    {
        public string Name { get; set; }

        public ViewCharactersInSerieDTO(Character c)
        {
            Name = c.Name;
        }
    }

    public class ViewFullCharacterDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public int SerieId { get; set; }
    }
    public class ViewUpdateCharacterDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public int SerieId { get; set; }
    }
}
