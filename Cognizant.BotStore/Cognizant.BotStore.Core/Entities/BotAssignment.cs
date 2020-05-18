using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class BotAssignment:BaseEntity
    {
        [Key]
        public int BotAssignmentID { get; set; }
        public int BotID { get; set; }
        public string Status { get; set; }
        public int TeamID { get; set; }
    }
}
