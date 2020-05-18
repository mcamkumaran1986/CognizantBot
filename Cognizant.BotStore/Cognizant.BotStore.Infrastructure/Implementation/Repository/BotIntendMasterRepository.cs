using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotIntendMasterRepository : IBotIntendMasterRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotIntendMasterRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BotIntendMaster>> GetBotIntendMaster()
        {
            try
            {
                return await _dbContext.BotIntendMaster.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BotIntendMaster>> GetBotIntendMasterById(int botId)
        {
            return await _dbContext.BotIntendMaster.AsNoTracking().Where(x => x.BotID == botId).ToListAsync();
        }

        public async Task<int> SaveBotIntendMaster(BotIntendMaster botIntendMaster)
        {
            try
            {
                var existsRelease = await _dbContext.BotIntendMaster.AsNoTracking().FirstOrDefaultAsync(x => x.BotIntendID == botIntendMaster.BotIntendID);
                if (existsRelease == null)
                {
                    _dbContext.BotIntendMaster.Add(botIntendMaster);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return botIntendMaster.BotIntendID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
