using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotSkillMaster
    {
        [Key]
        public int BotSkillID { get; set; }
        public int BotID { get; set; }
        public string SkillName { get; set; }
    }
}
