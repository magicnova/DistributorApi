using Distributor.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Distributor.Controllers
{
    [Route("api/[controller]")]
    public class DistributorController : Controller
    {
        private readonly IDistributorService _distributorService;

        public DistributorController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_distributorService.GetAll());
        }
    }
}