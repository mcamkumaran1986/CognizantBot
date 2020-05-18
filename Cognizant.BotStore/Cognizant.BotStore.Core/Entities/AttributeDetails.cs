using System.ComponentModel.DataAnnotations;

namespace Cognizant.BotStore.Core
{
    public class AttributeDetails
    {
        [Key]
        public int AttributeDetailID { get; set; }
        public int AssignmentID { get; set; }
        public int AttributeMasterID { get; set; }
        public string AttributeValue { get; set; }
    }
}
