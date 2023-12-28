using ActionApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class XmlActionController : ControllerBase
    {
        private readonly IServiceXmlAction _serviceXmlAction;

        public XmlActionController(IServiceXmlAction serviceXmlAction)
        {
            _serviceXmlAction = serviceXmlAction;
        }
        /// <summary>
        /// Add Main Categories.
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("AddMainCategories")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>>AddMainCategory()
        {
            return Ok(await _serviceXmlAction.AddMainCategory());

        }
        [HttpPost("AddSubCategories")]
        public async Task<ActionResult<bool>>AddSubCategory()
        {
            return Ok(_serviceXmlAction.AddSubCategory);
        }
        [HttpPost("AddProducts")]
    public async Task<ActionResult<bool>>AddProducts()
        {
            return Ok( await _serviceXmlAction.AddProduct());
        }
        [HttpPost("AddProducers")]
        public async Task<ActionResult<bool>>AddProducers()
        {
            return Ok(_serviceXmlAction.AddProducer);
        }
    }
}
