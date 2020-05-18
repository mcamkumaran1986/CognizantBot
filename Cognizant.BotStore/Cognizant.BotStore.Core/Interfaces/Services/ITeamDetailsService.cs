using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface ITeamDetailsService
    {
        Task<List<TeamDetails>> GetTeamDetails();
        Task<int> SaveTeamDetails(TeamDetails teamDetails);
    }
}
