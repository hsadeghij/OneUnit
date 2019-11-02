using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneUnit.Areas.QC.Data;
using OneUnit.Areas.QC.Data.Entities;
using OneUnit.Areas.QC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneUnit.Areas.QC.Controllers
{
    [Route("api/[Controller]")]
    public class QCApiController : Controller
    {
        private readonly IQCRepository _repository;
        private readonly ILogger<QCApiController> _logger;

        public QCApiController(IQCRepository repository, ILogger<QCApiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllQualityDesign());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products :{ex}");
                return Json("Bad Request");
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var qualitydesign = _repository.GetQualityDesignById(id);
                if (qualitydesign != null) return Ok(qualitydesign);
                else return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products :{ex}");
                return Json("Bad Request");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]QualityDesignViewModel model)
        {
            //add it do the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newQualityDesign = new QualityDesign()
                    {

                    };

                    _repository.AddEntity(model);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/qcapi/{model.Id}", model);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to save a new order:{ex}");
            }
            return BadRequest("Fsiled to Save new QualityDesign");
        }
    }
}
