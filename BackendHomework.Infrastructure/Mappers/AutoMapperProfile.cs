using AutoMapper;
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Entities;

namespace BackendHomework.Infrastructure.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Plate, PlateDTO>().ReverseMap();
            CreateMap<Plate, CreatePlateDTO>().ReverseMap();
        }
    }
}
