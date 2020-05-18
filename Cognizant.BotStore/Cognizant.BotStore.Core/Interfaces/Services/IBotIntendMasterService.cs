using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotIntendMasterService
    {
        Task<List<BotIntendMaster>> GetBotIntendMaster();
        Task<int> SaveBotIntendMaster(BotIntendMaster botIntendMaster);
    }
}
