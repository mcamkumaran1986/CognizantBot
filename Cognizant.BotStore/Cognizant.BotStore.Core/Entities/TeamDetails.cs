using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class TeamDetails: BaseEntity
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public bool Active { get; set; }
    }
}
