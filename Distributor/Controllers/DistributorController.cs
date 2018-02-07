using System.Linq;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Interfaces;
using Distributor.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distributor.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DistributorController : Controller
    {
        private readonly IDistributorService _distributorService;
        private readonly IFordService _fordService;

        public DistributorController(IDistributorService distributorService, IFordService fordService)
        {
            _distributorService = distributorService;
            _fordService = fordService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetAll());
            }

            return new UnauthorizedResult();
        }

        [HttpGet("model/{brand}/{model}")]
        public IActionResult GetByModel(string brand, string model)
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetByModel(brand, model));
            }

            return new UnauthorizedResult();
        }

        [HttpGet("transmission/{brand}/{transmission}")]
        public IActionResult GetByTransmission(string brand, string transmission)
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetByTransmission(brand, transmission));
            }

            return new UnauthorizedResult();
        }

        [HttpGet("engine/{brand}/{engine}")]
        public IActionResult GetByEngine(string brand, string engine)
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetByEngine(brand, engine));
            }

            return new UnauthorizedResult();
        }

        [HttpGet("year/{brand}/{year}")]
        public IActionResult GetByYear(string brand, int year)
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetByYear(brand, year));
            }

            return new UnauthorizedResult();
        }

        [HttpGet("{brand}/{id}")]
        public IActionResult GetById(string brand, string id)
        {
            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                return Ok(_distributorService.GetById(brand, id));
            }

            return new UnauthorizedResult();
        }

        [HttpPost("{brand}")]
        public IActionResult Post(string brand, [FromBody] CarRequest car)
        {
            if (brand.ToLower() != Brands.Ford.GetDesctiption().ToLower())
            {
                return StatusCode(500);
            }

            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                var status = _fordService.Create(car);
                return StatusCode(status);
            }

            return new UnauthorizedResult();
        }

        [HttpPut("{brand}")]
        public IActionResult Put(string brand, [FromBody] CarRequest car)
        {
            if (brand.ToLower() != Brands.Ford.GetDesctiption().ToLower())
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                var status = _fordService.Update(car);
                return StatusCode(status);
            }

            return new UnauthorizedResult();
        }

        [HttpDelete("{brand}/{id}")]
        public IActionResult Delete(string brand, string id)
        {
            if (brand.ToLower() != Brands.Ford.GetDesctiption().ToLower())
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

            var user = User.Claims?.FirstOrDefault(c => c.Type == "User")?.Value;

            if (user == "gp")
            {
                var status = _fordService.Delete(id);
                return StatusCode(status);
            }

            return new UnauthorizedResult();
        }
    }
}