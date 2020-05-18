using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botskillmaster")]
    [ApiController]
    public class BotSkillMasterController : ControllerBase
    {
        private readonly IBotSkillMasterService _botSkillMasterService;
        public BotSkillMasterController(IBotSkillMasterService botSkillMasterService)
        {
            _botSkillMasterService = botSkillMasterService;
        }
        [HttpGet("details")]
        public async Task<List<BotSkillMaster>> GetBotSkillMaster() => await _botSkillMasterService.GetBotSkillMaster();
        [HttpPost]
        public async Task<int> SaveBotSkillMaster(BotSkillMaster botSkillMaster) => await _botSkillMasterService.SaveBotSkillMaster(botSkillMaster);
    }
}