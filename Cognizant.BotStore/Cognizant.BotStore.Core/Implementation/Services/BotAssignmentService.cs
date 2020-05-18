using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotAssignmentService : IBotAssignmentService
    {
        private readonly IBotAssignmentRepository _botAssignmentRepository;
        public BotAssignmentService(IBotAssignmentRepository botAssignmentRepository)
        {
            _botAssignmentRepository = botAssignmentRepository;
        }

        public async Task<List<BotAssignment>> GetBotAssignment()
        {
            return await _botAssignmentRepository.GetBotAssignment();
        }

        public async Task<int> SaveBotAssignment(BotAssignment botAssignment)
        {
            return await _botAssignmentRepository.SaveBotAssignment(botAssignment);
        }
    }
}
