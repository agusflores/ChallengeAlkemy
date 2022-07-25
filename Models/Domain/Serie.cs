using ChallengeAlkemy.Models.ModelsMTM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChallengeAlkemy.Models.Domain
{
    public class Serie
    {
        private int _id;
        private string _img;
        private string _title;
        private DateTime _creation;
        private int _calification;
        private int _idGender; 

        [Key]
        public int Id { get { return _id; } set { _id = value; } }

        [Required]
        [Display(Name = "Image")]
        public string Image { get { return _img; } set { _img = value; } }

        [Required]
        [Display(Name = "Title")]
        public string Title { get { return _title; } set { _title = value; } }

        [Required]
        [Display(Name = "Creation")]
        public DateTime Creation { get { return _creation; } set { _creation = value; } }

        [Required]
        [Display(Name = "Calification")]
        public int Calification { get { return _calification; } set { _calification = value; } }

        [Required]
        [Display(Name = "Gender_Id")]
        public int GenderId { get { return _idGender; } set { _idGender = value; } }
        public List<CharacterSerie> Characters { get; set; }
        public Serie() { }
        public Serie(int id, string img, string title, DateTime creation, int calification, int genderId)
        {
            Characters = new List<CharacterSerie>();
            Id = id;
            _img = img;
            _title = title;
            _creation = creation;
            _calification = calification;
            _idGender = genderId;   
        }

        public Serie(string img, string title, DateTime creation, int calification, int genderId)
        {
            _img = img;
            _title = title;
            _creation = creation;
            _calification = calification;
            _idGender = genderId;
        }

        public void AddCharacters(Character character)
        {
            Characters.Add(new CharacterSerie { Character = character, Serie = this });
        }
        public List<Character> GetCharacters()
        {
            return Characters.Select(c => c.Character).ToList(); ;
        }


    }
}
