using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botlist")]
    [ApiController]
    public class BotListController : ControllerBase
    {
        private readonly IBotListService _botMasterService;
        public BotListController(IBotListService botMasterService)
        {
            _botMasterService = botMasterService;
        }
        [HttpGet("{id}")]
        public async Task<BotListDetails> GetBotById(int id) => await _botMasterService.GetBotMasterById(id);
        [HttpGet]
        public async Task<BotListing> GetBots() => await _botMasterService.GetBotMaster();

        [HttpPost]
        public async Task SaveBotDetails(BotListDetails botListDetails) => await _botMasterService.SaveBotMaster(botListDetails);
    }
}