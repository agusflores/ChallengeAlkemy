using ChallengeAlkemy.DTO.Gender;
using ChallengeAlkemy.Repository.Interfaces;
using ChallengeAlkemy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public class GenderService : IGenderService
    {
        private readonly IRepositoryGender _repositoryGender;

        public GenderService(IRepositoryGender repositoryGender)
        {
            _repositoryGender = repositoryGender;
        }

        public async Task<List<GetGendersDTO>> GetGenders()
        {
            var result = await _repositoryGender.GetGenders();
            var listGenders = new List<GetGendersDTO>();
            if (result == null) throw new Exception("Llego vacio");
            foreach (var item in result)
            {
                listGenders.Add(new GetGendersDTO(item.Name, item.Image, item.GetSeries()));
            }
            return listGenders;
        }
    }
}
