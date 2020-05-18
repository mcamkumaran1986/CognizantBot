using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class AttributeDetailsRepository: IAttributeDetailsRepository
    {
        private readonly BotStoreDBContext _dbContext;
        public AttributeDetailsRepository(BotStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AttributeDetails>> GetAttributeDetails()
        {
            try
            {
                return await _dbContext.AttributeDetails.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveAttributeDetails(AttributeDetails attributeDetails)
        {
            try
            {
                var existsRelease = await _dbContext.AttributeDetails.AsNoTracking().FirstOrDefaultAsync(x => x.AttributeDetailID == attributeDetails.AttributeDetailID);
                if (existsRelease == null)
                {
                    _dbContext.AttributeDetails.Add(attributeDetails);
                    await _dbContext.SaveChangesAsync();
                }
                //else
                //{
                //    teamDetails.TeamName = existsRelease.TeamName;
                //    _dbContext.TeamDetails.UpdateRange(teamDetails);
                //    await _dbContext.SaveChangesAsync();
                //}
                return attributeDetails.AssignmentID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
