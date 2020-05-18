using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotMasterService
    {
        Task<List<BotMaster>> GetBotMaster();
        Task<int> SaveBotMaster(BotMaster botMaster);
    }
}
