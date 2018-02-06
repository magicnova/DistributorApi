using System.Net;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Interfaces;
using Distributor.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distributor.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(_distributorService.GetAll());
        }

        [HttpGet("model/{brand}/{model}")]
        public IActionResult GetByModel(string brand,string model)
        {
            return Ok(_distributorService.GetByModel(brand, model));
        }
        
        [HttpGet("transmission/{brand}/{transmission}")]
        public IActionResult GetByTransmission(string brand,string transmission)
        {
            return Ok(_distributorService.GetByTransmission(brand, transmission));
        }
        
        [HttpGet("engine/{brand}/{engine}")]
        public IActionResult GetByEngine(string brand,string engine)
        {
            return Ok(_distributorService.GetByEngine(brand, engine));
        }
        
        [HttpGet("year/{brand}/{year}")]
        public IActionResult GetByYear(string brand,int year)
        {
            return Ok(_distributorService.GetByYear(brand, year));
        }
        
        [HttpGet("{brand}/{id}")]
        public IActionResult GetById(string brand,string id)
        {
            return Ok(_distributorService.GetById(brand, id));
        }

        [HttpPost("{brand}")]
        public IActionResult Post(string brand, [FromBody] CarRequest car)
        {
            if (brand.ToLower() != Brands.Ford.GetDesctiption().ToLower())
            {
                return StatusCode(500);
            }
            
            var status = _fordService.Create(car);
            return StatusCode(status);
        }  
    }
}