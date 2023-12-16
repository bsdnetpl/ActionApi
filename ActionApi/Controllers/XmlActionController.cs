using ActionApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlActionController : ControllerBase
    {
        private readonly IServiceXmlAction _serviceXmlAction;

        public XmlActionController(IServiceXmlAction serviceXmlAction)
        {
            _serviceXmlAction = serviceXmlAction;
        }
        [HttpPost("AddMainCategories")]
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
