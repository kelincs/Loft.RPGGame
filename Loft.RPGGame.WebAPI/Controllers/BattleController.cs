using Loft.RPGGame.Domain.Interfaces;
using Loft.RPGGame.Domain.Interfaces.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Loft.RPGGame.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {

        private readonly IBattleService _battleService;

        public BattleController(IBattleService battleService)
        {
            _battleService = battleService; 
        }

        [HttpPost("RunBattle")]
        public ActionResult<IBattleResult> Post([FromBody] List<Guid> input)
        {
            try
            {
                return Ok(_battleService.ExecuteBattle(input[0], input[1]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
