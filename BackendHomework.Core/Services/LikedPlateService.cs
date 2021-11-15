using BackendHomework.Core.Entities;
using BackendHomework.Core.Exceptions;
using BackendHomework.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendHomework.Core.Services
{
    public class LikedPlateService : ILikedPlateService
    {
        private readonly ILikedPlateRepository _likedPlateRepository;
        private readonly IPlateRepository _plateRepository;

        public LikedPlateService(ILikedPlateRepository likedPlateRepository, IPlateRepository plateRepository)
        {
            _likedPlateRepository = likedPlateRepository;
            _plateRepository = plateRepository;
        }

        public async Task<int> GeLikedPlatesCount(string userId)
        {
            return await _likedPlateRepository.GeLikedPlatesCount(userId);
        }

        public async Task<IEnumerable<LikedPlate>> GetUserLikedPlates(IPaginationFilter filter, string userId)
        {
            var likedPlates = _likedPlateRepository.GetUserLikedPlates(filter.PageNumber, filter.PageSize, userId);
            return await likedPlates.ToListAsync();
        }

        public async Task InsertLikedPlate(Guid plateId, User user)
        {
            //Validate that the plate is public and that it is not already liked
            var plate = await _plateRepository.GetById(plateId);

            if (plate != null)
            {
                if (plate.UserId != null)
                {
                    throw new BusinessException("The plate you are trying to like is not a public plate, please try with another plate");
                }

                var likedPlateAlreadyCreated = await _likedPlateRepository.IsLikedPlateAlreadyCreated(plateId, user.Id);

                if (likedPlateAlreadyCreated) 
                {
                    throw new BusinessException("You already liked this plate, please try another one");
                }

                var likedPlate = new LikedPlate
                {
                    Id = Guid.NewGuid(),
                    Plate = plate,
                    User = user
                };

                await _likedPlateRepository.Add(likedPlate);
            }
            else
            {
                throw new BusinessException("The plate you are trying to like does not exist, please try with another plate");
            }
        }
    }
}
