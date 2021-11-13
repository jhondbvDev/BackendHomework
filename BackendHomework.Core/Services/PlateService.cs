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

        public  IEnumerable<Plate> GetPlates()
        {
            var plates =   _plateRepository.GetAll() ;
            return plates;
        }

        public Task<IEnumerable<Plate>> GetPlatesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Plate>> GetPublicPlates()
        {
            throw new NotImplementedException();
        }

        public Task InsertPlate(Plate plate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlate(Plate plate)
        {
            throw new NotImplementedException();
        }


    }
}
