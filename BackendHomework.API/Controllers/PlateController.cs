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
                    var plate = new Plate 
                    {
                        Id = Guid.NewGuid(),
                        Name = dto.Name,
                        Description = dto.Description,
                        Price = dto.Price,
                        Type = dto.Type,
                        User = loggedUser,
                        UserId = loggedUser.Id
                    };

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
                return BadRequest(new Response<Exception>(ex));
            }
        }

        [HttpPut]
        [Route("editPlatePrice")]
        public async Task<IActionResult> EditPlatePrice(EditPlateDTO dto)
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

                if (loggedUserId != null)
                {
                    var plate = await _plateService.GetPlate(dto.PlateId);

                    if(plate != null) 
                    {
                        if (plate.UserId == loggedUserId)
                        {
                            plate.Price = dto.Price;
                            await _plateService.UpdatePlate(plate);

                            return Ok(new Response<string>("The plate price has been update successfully"));
                        }
                        else 
                        {
                            return BadRequest(new Response<string>("The plate you are trying to edit does not belong to you, please try with another plate"));
                        }
                    }
                    else 
                    {
                        return BadRequest(new Response<string>("The plate you are trying to edit does not exist, please try with another plate"));
                    }
                }
                else
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<Exception>(ex));
            }
        }

        [HttpDelete]
        [Route("deletePlate")]
        public async Task<IActionResult> DeletePlate(DeletePlateDTO dto)
        {
            try
            {
                //Getting values from jwt to link plate to the current user 
                var loggedUserId = JsonConvert.DeserializeObject<UserClaimDTO>(User.Claims.Where(c => c.Type == "UserData").FirstOrDefault().Value).Id;

                if (loggedUserId != null)
                {
                    var plate = await _plateService.GetPlate(dto.PlateId);

                    if (plate != null)
                    {
                        if (plate.UserId == loggedUserId)
                        {
                            await _plateService.DeletePlate(plate);

                            return Ok(new Response<string>("The plate has been deleted successfully"));
                        }
                        else
                        {
                            return BadRequest(new Response<string>("The plate you are trying to delete does not belong to you, please try with another plate"));
                        }
                    }
                    else
                    {
                        return BadRequest(new Response<string>("The plate you are trying to delete does not exist, please try with another plate"));
                    }
                }
                else
                {
                    return BadRequest(new Response<string>("There is no user actually logged into the server, please try again"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<Exception>(ex));
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
                return BadRequest(new Response<Exception>(ex));
            }
        }
    }
}
