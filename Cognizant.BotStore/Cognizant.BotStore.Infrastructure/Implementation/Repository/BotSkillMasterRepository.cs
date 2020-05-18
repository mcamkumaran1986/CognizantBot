using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotSkillMasterRepository : IBotSkillMasterRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public BotSkillMasterRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BotSkillMaster>> GetBotSkillMaster()
        {
            try
            {
                return await _dbContext.BotSkillMaster.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BotSkillMaster>> GetBotSkillMasterById(int botId)
        {
            try
            {
                return await _dbContext.BotSkillMaster.AsNoTracking().Where(x => x.BotID == botId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveBotSkillMaster(BotSkillMaster botSkillMaster)
        {
            try
            {
                var existsRelease = await _dbContext.BotSkillMaster.AsNoTracking().FirstOrDefaultAsync(x => x.BotSkillID == botSkillMaster.BotSkillID);
                if (existsRelease == null)
                {
                    _dbContext.BotSkillMaster.Add(botSkillMaster);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return botSkillMaster.BotSkillID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
