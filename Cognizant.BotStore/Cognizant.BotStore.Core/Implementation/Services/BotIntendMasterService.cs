using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotIntendMasterService : IBotIntendMasterService
    {
        private readonly IBotIntendMasterRepository _botIntendMasterRepository;
        public BotIntendMasterService(IBotIntendMasterRepository botIntendMasterRepository)
        {
            _botIntendMasterRepository = botIntendMasterRepository;
        }

        public async Task<List<BotIntendMaster>> GetBotIntendMaster()
        {
            return await _botIntendMasterRepository.GetBotIntendMaster();
        }

        public async Task<int> SaveBotIntendMaster(BotIntendMaster botIntendMaster)
        {
            return await _botIntendMasterRepository.SaveBotIntendMaster(botIntendMaster);
        }
    }
}
