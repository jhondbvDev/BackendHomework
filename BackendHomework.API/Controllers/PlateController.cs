using AutoMapper;
using BackendHomework.Core.DTOs;
using BackendHomework.Core.Entities;
using BackendHomework.Core.Exceptions;
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
        private readonly ILikedPlateService _likedPlateService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public PlateController(IPlateService plateService , ILikedPlateService likedPlateService, IMapper mapper, UserManager<User> userManager, IUriService uriService)
        {
            _plateService = plateService;
            _likedPlateService = likedPlateService;
            _mapper = mapper;
            _userManager = userManager;
            _uriService = uriService;
        }

        /// <summary>
        /// Get public plates  
        /// </summary>
        /// <returns>A public list of plates </returns>
        /// 
        [HttpGet]
        [Route("getPublicPlates")]
        public async Task<IActionResult> GetPublicPlates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var plates = await _plateService.GetPublicPlates(validFilter);
            var count = await _plateService.GetPublicCount();

            var platesDTO = _mapper.Map<List<PlateDTO>>(plates);
            var pagedReponse = PaginationHelper.CreatePagedResponse(platesDTO, validFilter, count, _uriService, route);

            return Ok(pagedReponse);
        }

        [HttpGet]
        [Route("getUserPlates")]
        public async Task<IActionResult> GetUserPlates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

            var plates = await _plateService.GetPlatesByUserId(validFilter, loggedUserId);
            var count = await _plateService.GetPrivateCount(loggedUserId);

            var platesDTO = _mapper.Map<List<PlateDTO>>(plates);
            var pagedReponse = PaginationHelper.CreatePagedResponse(platesDTO, validFilter, count, _uriService, route);

            return Ok(pagedReponse);
        }

        [HttpGet]
        [Route("getUserLikedPlates")]
        public async Task<IActionResult> GetUserLikedPlates([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

            var likedPlates = await _likedPlateService.GetUserLikedPlates(validFilter, loggedUserId);
            var count = await _likedPlateService.GeLikedPlatesCount(loggedUserId);

            var platesDTO = _mapper.Map<List<PlateDTO>>(likedPlates.Select(p => p.Plate).ToList());
            var pagedReponse = PaginationHelper.CreatePagedResponse(platesDTO, validFilter, count, _uriService, route);

            return Ok(pagedReponse);
        }

        [HttpPost]
        [Route("createPlate")]
        public async Task<IActionResult> CreatePlate(CreatePlateDTO dto) 
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                if (loggedUser != null)
                {
                    var plate = _mapper.Map<Plate>(dto);
                    plate.UserId = loggedUserId;
                    plate.User = loggedUser;

                    await _plateService.InsertPlate(plate);

                    return Ok(new Response<string>("The plate has been created successfully"));
                }
                else
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpPost]
        [Route("likePlate")]
        public async Task<IActionResult> LikePlate(Guid id)
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                if (loggedUser == null)
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }

                await _likedPlateService.InsertLikedPlate(id, loggedUser);

                return Ok(new Response<string>("The plate like has beed added sucessfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpPut]
        [Route("editPlatePrice")]
        public async Task<IActionResult> EditPlate(PlateDTO dto)
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

                if (loggedUserId == null)
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }

                Plate plate = _mapper.Map<Plate>(dto);
                await _plateService.UpdatePlate(plate, loggedUserId);

                return Ok(new Response<string>("the plate has been updated successfully "));
              
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpDelete]
        [Route("deletePlate")]
        public async Task<IActionResult> DeletePlate(Guid id)
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

                if (loggedUserId == null)
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }

                await _plateService.DeletePlate(id, loggedUserId);

                return Ok(new Response<string>("The plate has been deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

        [HttpDelete]
        [Route("deleteAllUserPlates")]
        public async Task<IActionResult> DeleteAllUserPlates()
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

                if (loggedUserId != null)
                {
                    var sucessfullDelete = await _plateService.DeleteAllUserPlates(loggedUserId);

                    if (sucessfullDelete) 
                    {
                        return Ok(new Response<string>("All user plates have been deleted successfully"));
                    }
                    else 
                    {
                        return Ok(new Response<string>("There were no plates to remove this time"));
                    }
                }
                else
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }
    }
}
