using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class IntendDetails
    {
        [Key]
        public int IntendDetailID { get; set; }
        public int AssignmentID { get; set; }
        public int IntendMasterID { get; set; }
        public string IntendValue { get; set; }
    }
}
