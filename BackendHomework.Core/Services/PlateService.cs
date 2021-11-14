using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> GetCount()
        {
            return await _plateRepository.GetCount();
        }

        public Task<Plate> GetPlate(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<Plate> GetPlates()
        {
            var plates = _plateRepository.GetAll();
            return plates;
        }

        public Task<IEnumerable<Plate>> GetPlatesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetPrivateCount(string userId)
        {
            var count = _plateRepository.GetPrivateCount(userId);
            return await count;
        }

        public Task<int> GetPrivateCount()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetPublicCount()
        {
            var count = _plateRepository.GetPublicCount();
            return await count;
        }

        public async Task<IEnumerable<Plate>> GetPublicPlates(IPaginationFilter filter)
        {
            var plates = _plateRepository.GetPublic(filter.PageNumber, filter.PageSize);
            return await plates.ToListAsync();
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
