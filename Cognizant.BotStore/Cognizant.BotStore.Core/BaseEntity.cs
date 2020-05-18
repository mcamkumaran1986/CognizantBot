using System;

namespace Cognizant.BotStore.Core
{
    public class BaseEntity
    {
        public DateTime CreatedTime { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
