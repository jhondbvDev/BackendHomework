using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BackendHomework.API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomAPIController : ControllerBase
    {

        [HttpGet]
        [Route("randomnumber")]
        public async Task<IActionResult> GetRandomNumber()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://csrng.net/csrng/csrng.php?min=0&max=1000");

                    if (response.IsSuccessStatusCode)
                    {
                        string message =  response.Content.ReadAsStringAsync().Result;

                        ResponseRandomAPI responseRandom = JsonConvert.DeserializeObject<List<ResponseRandomAPI>>(message).First();
                        return Ok(new ResponseMessage<Object>(new { RandomNumber=responseRandom.Random }));
                    }
                    else
                    {
                        return BadRequest(new ResponseMessage<string>("The service is temporaly out of services, try later."));
                    }

                  
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage<Exception>(ex));
            }
        }
    }
}
