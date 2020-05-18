using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamDetailsService _teamDetailsService;
        public TeamsController(ITeamDetailsService teamDetailsService)
        {
            _teamDetailsService = teamDetailsService;
        }
        [HttpGet("details")]
        public async Task<List<TeamDetails>> GetTeams() => await _teamDetailsService.GetTeamDetails();
        [HttpPost]
        public async Task<int> SaveTeamDetails(TeamDetails teamDetails) => await _teamDetailsService.SaveTeamDetails(teamDetails);
    }
}