using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotImageDetailsRepository : IBotImageDetailsRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotImageDetailsRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BotImageDetails>> GetBotImageNames()
        {
            try
            {
                return await _dbContext.BotImageDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveBotImageDetails(BotImageDetails botImageDetails)
        {
            try
            {
                var existsRelease = await _dbContext.BotImageDetails.AsNoTracking().FirstOrDefaultAsync(x => x.BotImageID == botImageDetails.BotImageID);
                if (existsRelease == null)
                {
                    _dbContext.BotImageDetails.Add(botImageDetails);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    botImageDetails.BotImageName = existsRelease.BotImageName;
                    _dbContext.BotImageDetails.UpdateRange(botImageDetails);
                    await _dbContext.SaveChangesAsync();
                }
                return botImageDetails.BotImageID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
