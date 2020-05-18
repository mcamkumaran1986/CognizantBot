using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotSkillMasterService: IBotSkillMasterService
    {
        private readonly IBotSkillMasterRepository _botSkillMasterRepository;
        public BotSkillMasterService(IBotSkillMasterRepository botSkillMasterRepository)
        {
            _botSkillMasterRepository = botSkillMasterRepository;
        }

        public async Task<List<BotSkillMaster>> GetBotSkillMaster()
        {
            return await _botSkillMasterRepository.GetBotSkillMaster();
        }

        public async Task<int> SaveBotSkillMaster(BotSkillMaster attributeDetails)
        {
            return await _botSkillMasterRepository.SaveBotSkillMaster(attributeDetails);
        }

    }
}
