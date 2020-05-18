using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface ITeamDetailsRepository
    {
        Task<List<TeamDetails>> GetTeamDetails();
        Task<int> SaveTeamDetails(TeamDetails teamDetails);
    }
}
