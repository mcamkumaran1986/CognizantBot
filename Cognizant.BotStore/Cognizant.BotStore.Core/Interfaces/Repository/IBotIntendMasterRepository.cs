using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotIntendMasterRepository
    {
        Task<List<BotIntendMaster>> GetBotIntendMaster();
        Task<List<BotIntendMaster>> GetBotIntendMasterById(int botId);
        Task<int> SaveBotIntendMaster(BotIntendMaster botIntendMaster);
    }
}
