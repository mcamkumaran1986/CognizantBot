using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class TeamDetailsRepository : ITeamDetailsRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public TeamDetailsRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TeamDetails>> GetTeamDetails()
        {
            try
            {
                return await _dbContext.TeamDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveTeamDetails(TeamDetails teamDetails)
        {
            try
            {
                var existsRelease = await _dbContext.TeamDetails.AsNoTracking().FirstOrDefaultAsync(x => x.TeamName == teamDetails.TeamName);
                if (existsRelease == null)
                {
                    _dbContext.TeamDetails.Add(teamDetails);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    teamDetails.TeamName = existsRelease.TeamName;
                    _dbContext.TeamDetails.UpdateRange(teamDetails);
                    await _dbContext.SaveChangesAsync();
                }
                return teamDetails.TeamID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
