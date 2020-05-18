using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotAttributeMasterRepository
    {
        Task<List<BotAttributeMaster>> GetBotAttributeMaster();
        Task<List<BotAttributeMaster>> GetBotAttributeMasterById(int botId);
        Task<int> SaveBotAttributeMaster(BotAttributeMaster botAttributeMaster);
    }
}
