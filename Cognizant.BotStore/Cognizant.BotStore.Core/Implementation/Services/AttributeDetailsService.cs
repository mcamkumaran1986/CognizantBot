using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class AttributeDetailsService: IAttributeDetailsService
    {
        private readonly IAttributeDetailsRepository _attributeDetailsRepository;
        public AttributeDetailsService(IAttributeDetailsRepository attributeDetailsRepository)
        {
            _attributeDetailsRepository = attributeDetailsRepository;
        }

        public async Task<List<AttributeDetails>> GetAttributeDetails()
        {
            return await _attributeDetailsRepository.GetAttributeDetails();
        }

        public async Task<int> SaveAttributeDetails(AttributeDetails attributeDetails)
        {
            return await _attributeDetailsRepository.SaveAttributeDetails(attributeDetails);
        }
    }
}
