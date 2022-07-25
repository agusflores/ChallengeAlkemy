using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChallengeAlkemy.Models.Domain
{
    public class Character
    {
        private string _img;
        private string _name;
        private int _age;
        private double _weight;
        private string _history;
        
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get { return _img; } set { _img = value; } }

        [Required]
        [Display(Name = "Name")]
        public string Name { get { return _name; } set { _name = value; } }

        [Required]
        [Display(Name = "Age")]
        public int Age { get { return _age; } set { _age = value; } }

        [Required]
        [Display(Name = "Weight")]
        public double Weight { get { return _weight; } set { _weight = value; } }

        [Required]
        [Display(Name = "History")]
        public string History { get { return _history; } set { _history = value; } }

        public List<CharacterSerie> Series { get; set; } 
       
        public Character() { }

        public Character(string img, string name, int age, double weight, string history)
        {
            Series = new List<CharacterSerie>(); 
            _img = img;
            _name = name;
            _age = age;
            _weight = weight;
            _history = history;
        }
        public void AddSeries(Serie serie)
        {
            Series.Add( new CharacterSerie { Serie = serie, Character = this });
        }
        public List<CharacterSerie> ViewSeries()
        {
            return Series.ToList();
        }
    }
}
