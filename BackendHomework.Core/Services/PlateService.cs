using BackendHomework.Core.Entities;
using BackendHomework.Core.Exceptions;
using BackendHomework.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<bool> DeletePlate(Guid plateId, string userId)
        {
            var plate = await this.GetPlate(plateId);

            if (plate != null)
            {
                if (plate.UserId != userId)
                {
                    throw new BusinessException("The plate you are trying to delete does not belong to you, please try with another plate");
                }

                return await _plateRepository.Delete(plate);
            }
            else
            {
                throw new BusinessException("The plate you are trying to delete does not exist, please try with another plate");
            }
        }

        public async Task<bool> DeleteAllUserPlates(string userId) 
        {
            return await _plateRepository.DeleteAllUserPlates(userId);
        }

        public async Task<int> GetCount()
        {
            return await _plateRepository.GetCount();
        }

        public async Task<Plate> GetPlate(Guid id)
        {
            return await _plateRepository.GetById(id);
        }

        public async Task<IEnumerable<Plate>> GetPlatesByUserId(IPaginationFilter filter, string userId)
        {
            var plates = _plateRepository.GetPlatesByUserId(filter.PageNumber, filter.PageSize, userId);
            return await plates.ToListAsync();
        }

        public async Task<int> GetPrivateCount(string userId)
        {
            var count = _plateRepository.GetPrivateCount(userId);
            return await count;
        }


        public async Task<int> GetPublicCount()
        {
            var count = _plateRepository.GetPublicCount();
            return await count;
        }

        public async Task<IEnumerable<Plate>> GetPublicPlates(IPaginationFilter filter)
        {
            var plates = _plateRepository.GetPublicPlates(filter.PageNumber, filter.PageSize);
            return await plates.ToListAsync();
        }


        public async Task InsertPlate(Plate plate)
        {
            await _plateRepository.Add(plate);
        }

        public async Task<bool> UpdatePlate(Plate plate,string userId)
        {
            var plateOld = await _plateRepository.GetById(plate.Id);

            if (plateOld != null)
            {
                if (plateOld.UserId != userId)
                {
                    throw new BusinessException("The plate you are trying to edit does not belong to you, please try with another plate");
                }

                plateOld.Description = plate.Description;
                plateOld.Price = plate.Price;
                plateOld.Name = plate.Name;
                plateOld.Type = plate.Type;
                
                return await _plateRepository.Update(plateOld);
            }
            else
            {
                throw new BusinessException("The plate you are trying to edit does not exist, please try with another plate");
            }
 
        }
    }
}
