using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts; 
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class Assets : ControllerBase
    {
        MainContext ctx = new MainContext();
        [HttpGet("ativos")]
        public IActionResult Get()
        {
            return Ok(ctx.Assets.ToList());
        }
    }
}
