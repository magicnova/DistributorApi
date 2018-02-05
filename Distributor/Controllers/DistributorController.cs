using Microsoft.AspNetCore.Mvc;

namespace Distributor.Controllers
{
    [Route("api/[controller]")]
    public class DistributorController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}