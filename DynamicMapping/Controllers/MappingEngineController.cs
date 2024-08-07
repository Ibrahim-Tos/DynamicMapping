using DynamicMapping.Core;
using DynamicMapping.Core.Errors;
using DynamicMapping.Extentions;
using FluentValidation;
using FluentValidation.Results;
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
        private IValidator<MappingModelBase> _validator;

        public MappingEngineController(IMappingEngineHandler mappingEngineHandler, IValidator<MappingModelBase> validator)
        {
            _mappingEngineHandler = mappingEngineHandler;
            _validator = validator;
        }

        /// <summary>
        /// Map clients model (json, xml..) to local model
        /// </summary>
        /// <param name="customerObject">Customers object mapping request to handle</param>
        /// <remarks>
        /// Sample success request:
        ///     {"id":123, "name":"altos", "Reservation": {"roomNumber":1, "guestQuantity":2}}
        /// Sample failure request:
        ///     {"id":0, "name":"altos", "Reservation": {"roomNumber":1, "guestQuantity":0}}
        /// </remarks>
        /// <response code="200">Returns the mapped local item</response>
        /// <response code="400">If the item is has validation errors</response>
        [SwaggerResponse((int)HttpStatusCode.OK, "Customers object has been mapped")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad request", typeof(ValidationErrorResponse))]
        [HttpPost("map-to-local")]
        public async Task<IActionResult> MapToLocal(string customerObject)
        {
            var result = await _mappingEngineHandler.MapToLocal(customerObject);
            ValidationResult validationResult = await _validator.ValidateAsync(result);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        /// <summary>
        /// Map local model to clients type (json, xml..)
        /// </summary>
        /// <param name="model">Model mapping request to handle</param>
        /// <remarks>
        /// Sample success request:
        ///     {"id":123, "organizationName":"altos", "Reservation": {"roomNumber":1, "guestQuantity":2}}
        /// Sample failure request:
        ///     {"id":0, "organizationName":"altos", "Reservation": {"roomNumber":1, "guestQuantity":0}}
        /// </remarks>
        /// <response code="200">Returns the mapped local item</response>
        /// <response code="400">If the item is has validation errors</response>
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Model has been mapped")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad request", typeof(ValidationErrorResponse))]
        [HttpPost("map-from-local")]
        public async Task<IActionResult> MapFromLocal(MappingModelBase model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return BadRequest(ModelState);
            }

            var result = await _mappingEngineHandler.MapFromLocal(model);

            return Ok(result);
        }
    }
}
