using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotMasterRepository : IBotMasterRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotMasterRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BotMaster>> GetBotMaster()
        {
            try
            {
                return await _dbContext.BotMaster.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BotMaster> GetBotMasterById(int botId)
        {
            try
            {
                return await _dbContext.BotMaster.AsNoTracking().Where(x => x.BotID == botId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveBotMaster(BotMaster botMaster)
        {
            try
            {
                var existBotMaster = await _dbContext.BotMaster.AsNoTracking().FirstOrDefaultAsync(x => x.BotID == botMaster.BotID);
                if (existBotMaster == null)
                {
                    _dbContext.BotMaster.Add(botMaster);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _dbContext.BotMaster.UpdateRange(botMaster);
                    await _dbContext.SaveChangesAsync();
                }
                return botMaster.BotID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
