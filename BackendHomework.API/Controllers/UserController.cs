using BackendHomework.API.Response;
using BackendHomework.Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackendHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        private const string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser(UserDTO dto)
        {
            try
            {
                if (!IsValidEmailAddress(dto.Email)) 
                {
                    return BadRequest(new ResponseMessage<string>("Please enter a valid email address"));
                }

                if (!PasswordContainsRequiredNonAlphanumericCharacters(dto.Password))
                {
                    return BadRequest(new ResponseMessage<string>("The password must contain at least one of these non-alphanumeric characters: !, @, #, ? or ]"));
                }

                var user = new IdentityUser
                {
                    UserName = dto.Email,
                    Email = dto.Email
                };

                var result = await _userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    return Ok(new ResponseMessage<string>("User created successfully"));
                }
                else 
                {
                    return BadRequest(new ResponseMessage<List<string>>(result.Errors.Select(e => e.Description).ToList()));
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserDTO dto)
        {
            try
            {
                var user = _userManager.Users.Where(user => user.Email == dto.Email).FirstOrDefault();

                if(user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

                    if (result.Succeeded)
                    {
                        return Ok(new ResponseMessage<string>("Login successful"));
                    }
                    else
                    {
                        return BadRequest(new ResponseMessage<string>("Login attempt failed, please check you're entering the right credentials"));
                    }
                }
                else 
                {
                    return BadRequest(new ResponseMessage<string>("The account email you're trying to use does not exist, please try again with an existing account"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage<Exception>(ex));
            }
        }

        private bool IsValidEmailAddress(string email) 
        {
            return Regex.IsMatch(email, emailRegex);
        }

        private bool PasswordContainsRequiredNonAlphanumericCharacters(string password) 
        {
            return password.Contains('!') || password.Contains('@') || password.Contains('#') || password.Contains('?') || password.Contains(']');
        }
    }
}
