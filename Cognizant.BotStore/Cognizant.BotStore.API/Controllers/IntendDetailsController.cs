using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/intenddetails")]
    [ApiController]
    public class IntendDetailsController : ControllerBase
    {
        private readonly IIntendDetailsService _intendDetailsService;
        public IntendDetailsController(IIntendDetailsService intendDetailsService)
        {
            _intendDetailsService = intendDetailsService;
        }
        [HttpGet("details")]
        public async Task<List<IntendDetails>> GetIntentDetails() => await _intendDetailsService.GetIntendDetails();
        [HttpPost]
        public async Task<int> SaveIntentDetails(IntendDetails intendDetails) => await _intendDetailsService.SaveIntendDetails(intendDetails);
    }
}