using Loft.RPGGame.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loft.RPGGame.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService; 
        }

        [HttpGet("GetAllOccupations")]
        public ActionResult<IList<IOccupation>> Get() 
        {
            return Ok(_occupationService.GetOccupations()); 
        }
    }
}
