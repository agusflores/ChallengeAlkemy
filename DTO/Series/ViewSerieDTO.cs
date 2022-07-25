using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using System;
using System.Collections.Generic;

namespace ChallengeAlkemy.DTO.Series
{
    public class ViewSerieDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime Creation { get; set; }
        public ViewSerieDTO(int id, string image, string title, DateTime creation)
        {
            Id = id;
            Image = image;
            Title = title;
            Creation = creation;
        }

    }
    public class ViewFullSerieDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime Creation { get; set; }
        public int Calification { get; set; }
        public int GenderId { get; set; }
        public List<ViewCharactersInSerieDTO> Characters { get; set; }

        public ViewFullSerieDTO()
        {
            Characters = new List<ViewCharactersInSerieDTO>();
        }
        
        public ViewFullSerieDTO(int id, string image, string title, DateTime creation, int calification, int genderId, List<Character> characters) 
            : this()
        {
            Id = id;
            Image = image;
            Title = title;
            Creation = creation;
            Calification = calification;
            GenderId = genderId;
            characters.ForEach(c => Characters.Add(new ViewCharactersInSerieDTO(c)));
        }
    }
    public class CreateSerieDTO
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime Creation { get; set; }
        public int Calification { get; set; }
        public int GenderId { get; set; }

    }
    public class UpdateSerieDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime Creation { get; set; }
        public int Calification { get; set; }
        public int GenderId { get; set; }

    }

}

