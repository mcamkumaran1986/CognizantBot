using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotMasterService : IBotMasterService
    {
        private readonly IBotMasterRepository _botMasterRepository;
        public BotMasterService(IBotMasterRepository botMasterRepository)
        {
            _botMasterRepository = botMasterRepository;
        }

        public async Task<List<BotMaster>> GetBotMaster()
        {
            return await _botMasterRepository.GetBotMaster();
        }
        public async Task<int> SaveBotMaster(BotMaster botMaster)
        {
            return await _botMasterRepository.SaveBotMaster(botMaster);
        }
    }
}
