using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class IntendDetailsRepository : IIntendDetailsRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public IntendDetailsRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<IntendDetails>> GetIntendDetails()
        {
            try
            {
                return await _dbContext.IntendDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveIntendDetails(IntendDetails intendDetails)
        {
            try
            {
                var existsRelease = await _dbContext.IntendDetails.AsNoTracking().FirstOrDefaultAsync(x => x.IntendDetailID == intendDetails.IntendDetailID);
                if (existsRelease == null)
                {
                    _dbContext.IntendDetails.Add(intendDetails);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return intendDetails.IntendDetailID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
