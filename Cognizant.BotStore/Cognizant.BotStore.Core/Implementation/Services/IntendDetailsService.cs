using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class IntendDetailsService : IIntendDetailsService
    {
        private readonly IIntendDetailsRepository _intendDetailsRepository;
        public IntendDetailsService(IIntendDetailsRepository intendDetailsRepository)
        {
            _intendDetailsRepository = intendDetailsRepository;
        }

        public async Task<List<IntendDetails>> GetIntendDetails()
        {
            return await _intendDetailsRepository.GetIntendDetails();
        }

        public async Task<int> SaveIntendDetails(IntendDetails intendDetails)
        {
            return await _intendDetailsRepository.SaveIntendDetails(intendDetails);
        }
    }
}
