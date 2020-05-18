using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botmaster")]
    [ApiController]
    public class BotMasterController : ControllerBase
    {
        private readonly IBotMasterService _botMasterService;
        public BotMasterController(IBotMasterService botMasterService)
        {
            _botMasterService = botMasterService;
        }
        [HttpGet("details")]
        public async Task<List<BotMaster>> GetBotMaster() => await _botMasterService.GetBotMaster();
        [HttpPost]
        public async Task<int> SaveBotMaster(BotMaster botMaster) => await _botMasterService.SaveBotMaster(botMaster);
    }
}