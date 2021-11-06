using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FerdsWebApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Policy = "RequireValidUsers")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetPotaena()
        {
            return "Yes it's working!";
        }
    }
}