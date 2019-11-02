using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneUnit.Data;
using OneUnit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController:Controller
    {
        private readonly IOneUnitRepository _repository;
        private readonly ILogger<ProductsController> _logger;
          
        public ProductsController(IOneUnitRepository repository,ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Faild to get products:{ex}");
                return BadRequest("Faild to get products");
            }
          
        }
            
    }
}
