using AutoMapper; 
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Entities;
using BackendHomework.Core.Interfaces;
using BackendHomework.Infrastructure.Helpers;
using BackendHomework.Infrastructure.Pagination;
using BackendHomework.Infrastructure.Responses;
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
        private readonly IUriService _uriService;
        public PlateController(IPlateService plateService , IMapper mapper, UserManager<User> userManager, IUriService uriService)
        {
            _plateService = plateService;
            _mapper = mapper;
            _userManager = userManager;
            _uriService = uriService;
        }

        /// <summary>
        /// Get plates public 
        /// </summary>
        /// <returns>A public list of plates </returns>
        [HttpGet]
        [Route("getPlates")]
        public async Task<IActionResult> GetPlates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var plates = await _plateService.GetPublicPlates(validFilter);
            var count = await _plateService.GetCount();
            var platesDTO = _mapper.Map<List<PlateDTO>>(plates);
            var pagedReponse = PaginationHelper.CreatePagedReponse<PlateDTO>(platesDTO, validFilter, count, _uriService, route);
            return Ok(pagedReponse);
        }

        [HttpPost]
        [Route("createPlate")]
        public async Task<IActionResult> CreatePlate(PlateDTO dto) 
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                if (loggedUser != null)
                {
                    var plate = _mapper.Map<Plate>(dto);
                    plate.Id = Guid.NewGuid();
                    plate.User = loggedUser;

                    await _plateService.InsertPlate(plate);

                    return Ok(new Response<string>("The plate has been created successfully"));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new Response<Exception>(ex));
            }
        }
    }
}
