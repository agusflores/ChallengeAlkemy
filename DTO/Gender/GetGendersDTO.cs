using System.Collections.Generic;
using ChallengeAlkemy.Models.Domain;

namespace ChallengeAlkemy.DTO.Gender
{
    public class GetGendersDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Serie> Series { get; set; }

        public GetGendersDTO(string name, string image, List<Serie> series)
        {
            Name = name;
            Image = image;
            Series = series;
        }
    }
}
