using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotAttributeMasterService
    {
        Task<List<BotAttributeMaster>> GetBotAttributeMaster();
        Task<int> SaveBotAttributeMaster(BotAttributeMaster botAttributeMaster);
    }
}
