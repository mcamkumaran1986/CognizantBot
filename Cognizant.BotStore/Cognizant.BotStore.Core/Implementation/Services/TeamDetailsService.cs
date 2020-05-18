using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class TeamDetailsService : ITeamDetailsService
    {
        private readonly ITeamDetailsRepository _teamDetailsRepository;
        public TeamDetailsService(ITeamDetailsRepository teamDetailsRepository)
        {
            _teamDetailsRepository = teamDetailsRepository;
        }

        public async Task<List<TeamDetails>> GetTeamDetails()
        {
            return await _teamDetailsRepository.GetTeamDetails();
        }

        public async Task<int> SaveTeamDetails(TeamDetails teamDetails)
        {
            return await _teamDetailsRepository.SaveTeamDetails(teamDetails);
        }
    }
}
