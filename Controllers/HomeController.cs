using System.Collections.Generic;
using System.Threading.Tasks;
using FerdsWebApp.DTOs;
using FerdsWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FerdsWebApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Policy = "RequireValidUsers")]
    public class HomeController : ControllerBase
    {
        private readonly INetzweltService _netzweltService;

        public HomeController(INetzweltService netzweltService)
        {
            _netzweltService = netzweltService;
        }

        [HttpGet]
        public async Task<ActionResult<ReturnTerritoryDto>> Get()
        {
            return await _netzweltService.GetTerritories();
        }
    }
}