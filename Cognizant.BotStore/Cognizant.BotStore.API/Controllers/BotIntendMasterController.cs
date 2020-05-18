using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botintendmaster")]
    [ApiController]
    public class BotIntendMasterController : ControllerBase
    {
        private readonly IBotIntendMasterService _botIntendMasterService;
        public BotIntendMasterController(IBotIntendMasterService botIntendMasterService)
        {
            _botIntendMasterService = botIntendMasterService;
        }
        [HttpGet("details")]
        public async Task<List<BotIntendMaster>> GetBotIntendMaster() => await _botIntendMasterService.GetBotIntendMaster();
        [HttpPost]
        public async Task<int> SaveBotIntentMaster(BotIntendMaster botIntendMaster) => await _botIntendMasterService.SaveBotIntendMaster(botIntendMaster);
    }
}