using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Services
{
    public class PlateService : IPlateService
    {
        private readonly IPlateRepository _plateRepository;
        public PlateService(IPlateRepository plateRepository)
        {
            _plateRepository = plateRepository;
        }
        public Task<bool> DeletePlate(Plate plate)
        {
            throw new NotImplementedException();
        }

        public Task<Plate> GetPlate(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plate> GetPlatesByUserId(string userId)
        {
            return _plateRepository.GetPlatesByUserId(userId);
        }

        public IEnumerable<Plate> GetPublicPlates()
        {
            return _plateRepository.GetPublicPlates();
        }

        public async Task InsertPlate(Plate plate)
        {
            await _plateRepository.Add(plate);
        }

        public Task<bool> UpdatePlate(Plate plate)
        {
            throw new NotImplementedException();
        }
    }
}
