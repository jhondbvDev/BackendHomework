using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendHomework.API.Response;
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class PlateController : ControllerBase
    {

        private readonly IPlateService _plateService;
        private readonly IMapper _mapper;
        public PlateController(IPlateService plateService , IMapper mapper)
        {
            _plateService = plateService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get()
        {
            //var plates = _plateService.GetPlates();
            //if (plates.Count() == 0)
            //    return NotFound();
            //var response = new ResponseMessage<IEnumerable<PlateDTO>>(_mapper.Map<IEnumerable<PlateDTO>>(plates));
            //return Ok(response);
            return Ok("Hola Mundo");
        }
    }
}
