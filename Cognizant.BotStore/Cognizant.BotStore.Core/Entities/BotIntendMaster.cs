using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotIntendMaster
    {
        [Key]
        public int BotIntendID { get; set; }
        public int BotID { get; set; }
        public string IntendName { get; set; }
    }
}
