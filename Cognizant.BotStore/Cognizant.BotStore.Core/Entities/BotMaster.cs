using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotMaster : BaseEntity
    {
        [Key]
        public int BotID { get; set; }
        public string BotName { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        public int? BotImageID { get; set; }
    }
}
