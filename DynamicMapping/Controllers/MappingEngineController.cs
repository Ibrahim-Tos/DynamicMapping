using DynamicMapping.Core;
using DynamicMapping.Core.Errors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DynamicMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingEngineController : ControllerBase
    {
        private readonly IMappingEngineHandler _mappingEngineHandler;

        public MappingEngineController(IMappingEngineHandler mappingEngineHandler)
        {
            _mappingEngineHandler = mappingEngineHandler;
        }

        /// <summary>
        /// Map clients model (json, xml..) to local model
        /// </summary>
        /// <param name="customerObject">Customers object mapping request to handle</param>
        [SwaggerResponse((int)HttpStatusCode.OK, "Customers object has been mapped")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad request", typeof(ValidationErrorResponse))]
        [HttpGet("map-to-local")]
        public IActionResult MapToLocal(string customerObject)
        {
            var result = _mappingEngineHandler.MapToLocal(customerObject);

            return Ok(result);
        }

        /// <summary>
        /// Map local model to clients type (json, xml..)
        /// </summary>
        /// <param name="model">Model mapping request to handle</param>
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Model has been mapped")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad request", typeof(ValidationErrorResponse))]
        [HttpGet("map-from-local")]
        public IActionResult MapFromLocal(MappingModelBase model)
        {
            var result = _mappingEngineHandler.MapFromLocal(model);

            return Ok(result);
        }
    }
}
