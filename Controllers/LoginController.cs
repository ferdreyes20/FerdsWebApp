using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FerdsWebApp.DTOs;
using FerdsWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FerdsWebApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private  INetzweltService _netzweltService;
        public LoginController(INetzweltService netzweltService)
        {
            _netzweltService = netzweltService;
        }

        [HttpPost("AuthUser")]
        public async Task<ActionResult<string>> AutenticateUser(AuthUserDto authUserDTO) {
            if(!ModelState.IsValid)
            {
               return BadRequest(ModelState.Values.SelectMany(v => v.Errors)); 
            }

            var userResult = await _netzweltService.GetUser(authUserDTO);
            if(!string.IsNullOrEmpty(userResult.Error))
                return BadRequest(userResult.Error);
            
            return Ok(userResult);
        }
    }
}