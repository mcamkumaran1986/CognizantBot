using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/botassignment")]
    [ApiController]
    public class BotAssignmentController : ControllerBase
    {
        private readonly IBotAssignmentService _botAssignmentService;
        public BotAssignmentController(IBotAssignmentService botAssignmentService)
        {
            _botAssignmentService = botAssignmentService;
        }
        [HttpGet("details")]
        public async Task<List<BotAssignment>> GetBotAssignment() => await _botAssignmentService.GetBotAssignment();
        [HttpPost]
        public async Task<int> SaveBotAssignment(BotAssignment botAssignment) => await _botAssignmentService.SaveBotAssignment(botAssignment);
    }
}