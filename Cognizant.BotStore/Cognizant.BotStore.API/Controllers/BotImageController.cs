using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botimage")]
    [ApiController]
    public class BotImageController : ControllerBase
    {
        private readonly IBotImageDetailsService _botImageDetailsService;
        public BotImageController(IBotImageDetailsService botImageDetailsService)
        {
            _botImageDetailsService = botImageDetailsService;
        }
        [HttpGet("display")]
        public async Task<List<BotImageDetails>> GetImageNames() => await _botImageDetailsService.GetBotImageNames();
        [HttpPost]
        public async Task<int> SaveImageDetails(BotImageDetails botImageDetails) => await _botImageDetailsService.SaveBotImageDetails(botImageDetails);
    }
}