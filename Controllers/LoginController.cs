using System.Linq;
using System.Threading.Tasks;
using FerdsWebApp.DTOs;
using FerdsWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FerdsWebApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly INetzweltService _netzweltService;
        private readonly ITokenService _tokenService;

        public LoginController(INetzweltService netzweltService, ITokenService tokenService)
        {
            _netzweltService = netzweltService;
            _tokenService = tokenService;
        }

        [HttpPost("AuthUser")]
        public async Task<ActionResult<ReturnAuthUserDto>> AutenticateUser(AuthUserDto authUserDTO) {
            if(!ModelState.IsValid)
            {
               return BadRequest(ModelState.Values.SelectMany(v => v.Errors)); 
            }

            var returnUserDto = await _netzweltService.GetUser(authUserDTO);
            if(!string.IsNullOrEmpty(returnUserDto.Error))
                return BadRequest(returnUserDto.Error);

            returnUserDto.Token = _tokenService.CreateToken(returnUserDto);
            return Ok(returnUserDto);
        }
    }
}