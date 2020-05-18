using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotAssignmentRepository : IBotAssignmentRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotAssignmentRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BotAssignment>> GetBotAssignment()
        {
            try
            {
                return await _dbContext.BotAssignment.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveBotAssignment(BotAssignment botAssignment)
        {
            try
            {
                var existsRelease = await _dbContext.BotAssignment.AsNoTracking().FirstOrDefaultAsync(x => x.BotAssignmentID == botAssignment.BotAssignmentID);
                if (existsRelease == null)
                {
                    _dbContext.BotAssignment.Add(botAssignment);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return botAssignment.BotAssignmentID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
