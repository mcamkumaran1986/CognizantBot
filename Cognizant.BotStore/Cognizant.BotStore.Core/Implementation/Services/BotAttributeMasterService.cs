using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public  class BotAttributeMasterService: IBotAttributeMasterService
    {
        private readonly IBotAttributeMasterRepository _botAttributeMasterRepository;
        public BotAttributeMasterService(IBotAttributeMasterRepository botAttributeMasterRepository)
        {
            _botAttributeMasterRepository = botAttributeMasterRepository;
        }

        public async Task<List<BotAttributeMaster>> GetBotAttributeMaster()
        {
            return await _botAttributeMasterRepository.GetBotAttributeMaster();
        }

        public async Task<int> SaveBotAttributeMaster(BotAttributeMaster botAttributeMaster)
        {
            return await _botAttributeMasterRepository.SaveBotAttributeMaster(botAttributeMaster);
        }
    }
}
