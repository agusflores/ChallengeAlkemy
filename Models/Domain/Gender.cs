using ChallengeAlkemy.Models.ModelsMTM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlkemy.Models.Domain
{
    public class Gender
    {
        private int _id;
        private string _img;
        private string _name;

        [Key]
        public int Id { get { return _id; } set { _id = value; } }

        [Required]
        [Display(Name = "Image")]
        public string Image { get { return _img; } set { _img = value; } }

        [Required]
        [Display(Name = "Name")]
        public string Name { get { return _name; } set { _name = value; } }
        public List<Serie> Series { get; set; }
        public Gender() 
        {
            Series = new List<Serie>();
        }
        public Gender(int id, string img, string name, Serie Serie)
            : this()
        {
            _id = id;
            _img = img;
            _name = name;
            AddSeries(Serie);
        }
        public void AddSeries(Serie Serie)
        {
            Series.Add(Serie);
        }
        public List<Serie> GetSeries()
        {
            return Series;
        }

    }
}
