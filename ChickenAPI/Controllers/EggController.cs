using Microsoft.AspNetCore.Mvc;

namespace ChickenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EggController : Controller
    {
        [HttpGet("/GetEggs")]
        public ActionResult<string> GetEggs()
        {
            return Ok("Here are the eggs!");
        }
    }
}