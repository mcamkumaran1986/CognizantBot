using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotAttributeMasterRepository : IBotAttributeMasterRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotAttributeMasterRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BotAttributeMaster>> GetBotAttributeMaster()
        {
            try
            {
                return await _dbContext.BotAttributeMaster.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BotAttributeMaster>> GetBotAttributeMasterById(int botId)
        {
            try
            {
                return await _dbContext.BotAttributeMaster.AsNoTracking().Where(x => x.BotID == botId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveBotAttributeMaster(BotAttributeMaster botAttributeMaster)
        {
            try
            {
                var existsRelease = await _dbContext.BotAttributeMaster.AsNoTracking().FirstOrDefaultAsync(x => x.BotAttributeID == botAttributeMaster.BotAttributeID);
                if (existsRelease == null)
                {
                    _dbContext.BotAttributeMaster.Add(botAttributeMaster);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return botAttributeMaster.BotAttributeID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
