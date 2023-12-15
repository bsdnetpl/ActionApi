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
        public ActionResult<bool>AddMainCategory()
        {
            return Ok(_serviceXmlAction.AddMainCategory());

        }
        [HttpPost("AddSubCategories")]
        public ActionResult<bool> AddSubCategory()
        {
            return Ok(_serviceXmlAction.AddSubCategory);
        }
        [HttpPost("AddProducts")]
        public ActionResult<bool> AddProducts()
        {
            return Ok(_serviceXmlAction.AddProduct());
        }
        [HttpPost("AddProducers")]
        public ActionResult<bool> AddProducers()
        {
            return Ok(_serviceXmlAction.AddProducer);
        }
    }
}
