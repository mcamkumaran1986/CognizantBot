using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotImageDetailsService : IBotImageDetailsService
    {
        private readonly IBotImageDetailsRepository _botImageDetailsRepository;
        public BotImageDetailsService(IBotImageDetailsRepository botImageDetailsRepository)
        {
            _botImageDetailsRepository = botImageDetailsRepository;
        }

        public async Task<List<BotImageDetails>> GetBotImageNames()
        {
            return await _botImageDetailsRepository.GetBotImageNames();
        }

        public async Task<int> SaveBotImageDetails(BotImageDetails botImageDetails)
        {
            return await _botImageDetailsRepository.SaveBotImageDetails(botImageDetails);
        }
    }
}
