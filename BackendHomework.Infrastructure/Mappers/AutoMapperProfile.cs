using AutoMapper;
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendHomework.Infrastructure.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Plate, PlateDTO>().ReverseMap();
        }
        
    }
}
