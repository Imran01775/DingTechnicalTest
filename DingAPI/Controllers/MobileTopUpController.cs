
using System.Xml.Linq;
using Dimng.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace DingAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class MobileTopUpController : ControllerBase
    {

        private readonly IMobileTopUpService _mobileTopUpService;
        public MobileTopUpController(IMobileTopUpService mobileTopUpService)
        {
            _mobileTopUpService = mobileTopUpService;
        }
        [HttpPost]
        public IActionResult Post([FromBody]XElement xml)
        {
            return Ok(_mobileTopUpService.MobileTopUp(xml));
        }
    }
}