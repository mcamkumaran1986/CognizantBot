using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotSkillMasterService
    {
        Task<List<BotSkillMaster>> GetBotSkillMaster();
        Task<int> SaveBotSkillMaster(BotSkillMaster botSkillMaster);
    }
}
