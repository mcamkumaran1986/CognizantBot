using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotAttributeMaster
    {
        [Key]
        public int BotAttributeID { get; set; }
        public int BotID { get; set; }
        public string AttributeName { get; set; }
    }
}
