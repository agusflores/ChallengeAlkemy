using ChallengeAlkemy.DTO.Characters;
using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using ChallengeAlkemy.Repository.Interfaces;
using ChallengeAlkemy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryCharacter _characterRepository;
        public CharacterService(IRepositoryCharacter characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<Character> CreateCharacter(ViewFullCharacterDTO viewFullCharacterDTO)
        {
            if (viewFullCharacterDTO == null)
            {
                throw new Exception("Llego vacio");
            }
            var result = await _characterRepository.FindSerie(viewFullCharacterDTO.SerieId);
            if (result == null) { throw new Exception("No se encontro la serie con ese ID"); }
            var character = new Character(viewFullCharacterDTO.Image, viewFullCharacterDTO.Name, viewFullCharacterDTO.Age, viewFullCharacterDTO.Weight, viewFullCharacterDTO.History);
            character.AddSeries(result);
            await _characterRepository.CreateCharacter(character);
            await _characterRepository.SaveChanges();
            return character;
        }
        public async Task<Character> UpdateCharacter(ViewUpdateCharacterDTO viewUpdateCharacterDTO)
        {
            if (viewUpdateCharacterDTO == null)
            {
                throw new Exception("Llego vacio");
            }
            var result = await _characterRepository.FindCharacterById(viewUpdateCharacterDTO.Id);
            if (result == null) { throw new Exception("No se encontro el personaje con ese ID"); }
            result.Image = viewUpdateCharacterDTO.Image;
            result.Name = viewUpdateCharacterDTO.Name;
            result.Age = viewUpdateCharacterDTO.Age;
            result.Weight = viewUpdateCharacterDTO.Weight;
            result.History = viewUpdateCharacterDTO.History;
            await _characterRepository.UpdateCharacter(result);
            await _characterRepository.SaveChanges();
            return result;
        }
        public async Task<List<ViewFullCharacterDTO>> Find()
        {
            var result = new List<ViewFullCharacterDTO>();
            foreach (var item in await _characterRepository.FindCharacters(null, null, null))
            {
                result.Add(new ViewFullCharacterDTO { Image = item.Image, Name = item.Name, Age = item.Age, History = item.History, Weight = item.Weight }); //Agregar series relacionados.
            }
            return result;
        }
        public async Task<List<ViewCharacterDTO>> FindCharacters(string name, int? age, int? idSerie)
        {
            var result = new List<ViewCharacterDTO>();
            foreach (var item in await _characterRepository.FindCharacters(name, age, idSerie))
            {
                result.Add(new ViewCharacterDTO { Image = item.Image, Name = item.Name });
            }
            return result;
        }


        public async Task<Character> DeleteCharacter(int id)
        {
            var result = await _characterRepository.FindCharacterById(id);
            if (result == null) { throw new Exception("Llego vacio"); }
            await _characterRepository.DeleteCharacter(result);
            await _characterRepository.SaveChanges();
            return result;
        }
    }
}
