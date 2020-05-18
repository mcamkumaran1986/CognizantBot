using System.Collections.Generic;

namespace Cognizant.BotStore.Core
{
    public class BotListDetails
    {
        public BotMaster BotMasters { get; set; }
        public List<BotIntendMaster> BotIntendMasters { get; set; }
        public List<BotSkillMaster> BotSkillMasters { get; set; }
        public List<BotAttributeMaster> BotAttributeMasters { get; set; }
    }
}
