using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botattributemaster")]
    [ApiController]
    public class BotAttributeMasterController : ControllerBase
    {
        private readonly IBotAttributeMasterService _botAttributeMasterService;
        public BotAttributeMasterController(IBotAttributeMasterService botAttributeMasterService)
        {
            _botAttributeMasterService = botAttributeMasterService;
        }
        [HttpGet("details")]
        public async Task<List<BotAttributeMaster>> GetBotAttributeMaster() => await _botAttributeMasterService.GetBotAttributeMaster();
        [HttpPost]
        public async Task<int> SaveBotAttributeMaster(BotAttributeMaster botAttributeMaster) => await _botAttributeMasterService.SaveBotAttributeMaster(botAttributeMaster);
    }
}