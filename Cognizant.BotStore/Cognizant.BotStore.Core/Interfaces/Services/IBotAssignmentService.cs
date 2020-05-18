using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotAssignmentService
    {
        Task<List<BotAssignment>> GetBotAssignment();
        Task<int> SaveBotAssignment(BotAssignment botAssignment);
    }
}
