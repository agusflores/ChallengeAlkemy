using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.DTO.Series;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using ChallengeAlkemy.Repository.Interfaces;
using ChallengeAlkemy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public class SerieService : ISerieService
    {
        private readonly IRepositorySerie _repositorySerie;
        public SerieService(IRepositorySerie serieRepository)
        {
            _repositorySerie = serieRepository;
        }
        public async Task<List<ViewSerieDTO>> FindSeries()
        {
            var list = new List<ViewSerieDTO>();
            foreach (var item in await _repositorySerie.FindSeries())
            {
                list.Add(new ViewSerieDTO(item.Id, item.Image, item.Title, item.Creation));
            }
            return list;
        }
        public async Task<List<ViewFullSerieDTO>> Find()
        {
            var result = new List<ViewFullSerieDTO>();
            foreach (var item in await _repositorySerie.FindSeries())
            {
                result.Add(new ViewFullSerieDTO(item.Id, item.Image, item.Title, item.Creation, item.Calification, item.GenderId, item.GetCharacters()));
            }
            return result;
        }
        public async Task<Serie> CreateSerie(CreateSerieDTO createSerieDTO)
        {
            if (createSerieDTO == null)
            {
                throw new Exception("LLego vacio");
            }
            if (createSerieDTO.Creation > DateTime.Now) throw new Exception("La fecha ingresada es incorrecta!");
            if (createSerieDTO.Calification < 1 || createSerieDTO.Calification > 5) throw new Exception("La calificacion debe ser entre 1-5!");
            if (await _repositorySerie.SerieExists(createSerieDTO.Title)) throw new Exception("Ya existe una serie con ese titulo!!");
            if (createSerieDTO.GenderId < 1 || createSerieDTO.GenderId > 7) throw new Exception("No existe ningun Genero con ese ID");
            Serie serie = new Serie(createSerieDTO.Image, createSerieDTO.Title, createSerieDTO.Creation, createSerieDTO.Calification, createSerieDTO.GenderId); ;
            var result = await _repositorySerie.GetGender(createSerieDTO.GenderId);
            serie.GenderId = createSerieDTO.GenderId;
            result.AddSeries(serie);
            await _repositorySerie.CreateSerie(serie);
            await _repositorySerie.SaveChanges();
            return serie;
        }
        public async Task<Serie> UpdateSerie(UpdateSerieDTO updateSerieDTO)
        {
            if (updateSerieDTO == null) throw new Exception("Llego vacio");
            var serie = await _repositorySerie.GetSerie(updateSerieDTO.Id);
            if (serie == null) throw new Exception("No existe la serie con ese ID");
            if (updateSerieDTO.Creation > DateTime.Now) throw new Exception("La fecha ingresada es incorrecta!");
            if (updateSerieDTO.Calification < 1 || updateSerieDTO.Calification > 5) throw new Exception("La calificacion debe ser entre 1-5!");
            if (await _repositorySerie.SerieExists(updateSerieDTO.Title)) throw new Exception("Ya existe una serie con ese titulo!!");
            if (updateSerieDTO.GenderId < 1 || updateSerieDTO.GenderId > 7) throw new Exception("No existe ningun genero con ese ID");
            serie.Title = updateSerieDTO.Title;
            serie.Image = updateSerieDTO.Image;
            serie.Creation = updateSerieDTO.Creation;
            serie.Calification = updateSerieDTO.Calification;
            await _repositorySerie.UpdateSerie(serie);
            await _repositorySerie.SaveChanges();
            return serie;
        }
        public async Task<Serie> DeleteSerie(int id)
        {
            var serieDelete = await _repositorySerie.GetSerie(id);
            if (serieDelete == null) throw new Exception("No existe la serie con ese ID");
            await _repositorySerie.DeleteSerie(serieDelete);
            await _repositorySerie.SaveChanges();
            return serieDelete;
        }

        public async Task<List<ViewSerieDTO>> FindSeriesByQuery(string title, int? idGender)
        {
            var result = new List<ViewSerieDTO>();
            foreach (var item in await _repositorySerie.FindSeriesQuery(title, idGender))
            {
                result.Add(new ViewSerieDTO(item.Id, item.Image, item.Title, item.Creation));
            }
            return result;

        }
    }
}
