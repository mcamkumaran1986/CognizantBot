using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotSkillMasterRepository
    {
        Task<List<BotSkillMaster>> GetBotSkillMaster();
        Task<List<BotSkillMaster>> GetBotSkillMasterById(int botId);
        Task<int> SaveBotSkillMaster(BotSkillMaster botSkillMaster);
    }
}
