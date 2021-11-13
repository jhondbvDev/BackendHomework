using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PlateController(IPlateService plateService)
        {
            _plateService = plateService;
        }
            
    }
}
