using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FerdsWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FerdsWebApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("AuthUser")]
        public async Task<ActionResult<string>> AutenticateUser(AuthUserDTO authUserDTO) {
            if(!ModelState.IsValid)
            {
               return BadRequest(ModelState.Values.SelectMany(v => v.Errors)); 
            }

            var url = "https://netzwelt-devtest.azurewebsites.net/Account/SignIn";
            var json = JsonConvert.SerializeObject(authUserDTO);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(url, data);
                return Ok(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}