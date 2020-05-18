using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotMasterRepository
    {
        Task<List<BotMaster>> GetBotMaster();
        Task<BotMaster> GetBotMasterById(int botId);
        Task<int> SaveBotMaster(BotMaster botMaster);
    }
}
