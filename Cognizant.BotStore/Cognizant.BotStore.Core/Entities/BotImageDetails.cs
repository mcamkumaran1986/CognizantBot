using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotImageDetails
    {
        [Key]
        public int BotImageID { get; set; }
        public string BotImageName { get; set; }
    }
}
