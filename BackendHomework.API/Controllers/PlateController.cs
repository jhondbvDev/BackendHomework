using AutoMapper;
using BackendHomework.API.Response;
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlateController : ControllerBase
    {

        private readonly IPlateService _plateService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public PlateController(IPlateService plateService , IMapper mapper, UserManager<User> userManager)
        {
            _plateService = plateService;
            _mapper = mapper;
            _userManager = userManager;
        }

        /// <summary>
        /// Get public plates  
        /// </summary>
        /// <returns>A public list of plates </returns>
        /// 
        [HttpGet]
        [Route("getPublicPlates")]
        public IActionResult GetPublicPlates()
        {
            var plates = _plateService.GetPublicPlates();

            return Ok(new ResponseMessage<IEnumerable<PlateDTO>>(_mapper.Map<IEnumerable<PlateDTO>>(plates)));
        }

        [HttpGet]
        [Route("getUserAndPublicPlates")]
        public IActionResult GetUserAndPublicPlates()
        {
            var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;
            var plates = _plateService.GetPlatesByUserId(loggedUserId);

            return Ok(new ResponseMessage<IEnumerable<PlateDTO>>(_mapper.Map<IEnumerable<PlateDTO>>(plates)));
        }

        [HttpPost]
        [Route("createPlate")]
        public async Task<IActionResult> CreatePlate(PlateDTO dto) 
        {
            try
            {
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                if(loggedUser != null) 
                {
                    var plate = _mapper.Map<Plate>(dto);
                    plate.Id = Guid.NewGuid();
                    plate.User = loggedUser;

                    await _plateService.InsertPlate(plate);

                    return Ok(new ResponseMessage<string>("The plate has been created successfully"));
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new ResponseMessage<Exception>(ex));
            }
        }
    }
}
