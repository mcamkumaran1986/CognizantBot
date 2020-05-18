using Cognizant.BotStore.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Cognizant.BotStore.API.Controllers
{
    [Route("api/attributedetails")]
    [ApiController]
    public class AttributeDetailsController : ControllerBase
    {
        private readonly IAttributeDetailsService _attributeDetailsService;
        public AttributeDetailsController(IAttributeDetailsService attributeDetailsService)
        {
            _attributeDetailsService = attributeDetailsService;
        }
        [HttpGet("details")]
        public async Task<List<AttributeDetails>> GetAttributes() => await _attributeDetailsService.GetAttributeDetails();
        [HttpPost]
        public async Task<int> SaveAttributeDetails(AttributeDetails attributeDetails) => await _attributeDetailsService.SaveAttributeDetails(attributeDetails);
    }
}