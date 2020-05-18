using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotListService : IBotListService
    {
        private readonly IBotMasterRepository _botMasterRepository;
        private readonly IBotIntendMasterRepository _botIntendMasterRepository;
        private readonly IBotSkillMasterRepository _botSkillMasterRepository;
        private readonly IBotAttributeMasterRepository _botAttributeMasterRepository;
        public BotListService(
                                        IBotMasterRepository botMasterRepository,
                                        IBotIntendMasterRepository botIntendMasterRepository,
                                        IBotSkillMasterRepository botSkillMasterRepository,
                                        IBotAttributeMasterRepository botAttributeMasterRepository
            )
        {
            _botMasterRepository = botMasterRepository;
            _botIntendMasterRepository = botIntendMasterRepository;
            _botSkillMasterRepository = botSkillMasterRepository;
            _botAttributeMasterRepository = botAttributeMasterRepository;
        }
        public async Task<BotListing> GetBotMaster()
        {
            BotListing botListing = new BotListing
            {
                BotMasters = await _botMasterRepository.GetBotMaster(),
                BotIntendMasters = await _botIntendMasterRepository.GetBotIntendMaster(),
                BotSkillMasters = await _botSkillMasterRepository.GetBotSkillMaster(),
                BotAttributeMasters = await _botAttributeMasterRepository.GetBotAttributeMaster()
            };
            return botListing;
        }
        public async Task<BotListDetails> GetBotMasterById(int botId)
        {
            BotListDetails botListDetails = new BotListDetails
            {
                BotMasters = await _botMasterRepository.GetBotMasterById(botId),
                BotSkillMasters = await _botSkillMasterRepository.GetBotSkillMasterById(botId),
                BotIntendMasters = await _botIntendMasterRepository.GetBotIntendMasterById(botId),
                BotAttributeMasters = await _botAttributeMasterRepository.GetBotAttributeMasterById(botId)
            };
            return botListDetails;
        }

        public async Task SaveBotMaster(BotListDetails botListDetails)
        {
            BotMaster botMaster = new BotMaster
            {
                BotName = botListDetails.BotMasters.BotName,
                BotID = botListDetails.BotMasters.BotID,
                ImagePath = botListDetails.BotMasters.ImagePath,
                BotImageID= botListDetails.BotMasters.BotImageID,
                Active = botListDetails.BotMasters.Active,
                CreatedBy= botListDetails.BotMasters.CreatedBy,
                CreatedTime = botListDetails.BotMasters.CreatedTime,
                ModifiedBy = botListDetails.BotMasters.ModifiedBy,
                ModifiedTime = botListDetails.BotMasters.ModifiedTime,
            };
            int botId = await _botMasterRepository.SaveBotMaster(botMaster);

            //Intend Master

            foreach (BotIntendMaster botIntendMasters in botListDetails.BotIntendMasters)
            {
                BotIntendMaster botIntendMaster = new BotIntendMaster
                {
                    BotID = botId,
                    BotIntendID = botIntendMasters.BotIntendID,
                    IntendName = botIntendMasters.IntendName,
                };
                await _botIntendMasterRepository.SaveBotIntendMaster(botIntendMaster);
            }

            //Skill Master
            foreach (BotSkillMaster botSkillMasters in botListDetails.BotSkillMasters)
            {
                BotSkillMaster botSkillMaster = new BotSkillMaster
                {
                    BotID = botId,
                    BotSkillID = botSkillMasters.BotSkillID,
                    SkillName = botSkillMasters.SkillName,
                };
                await _botSkillMasterRepository.SaveBotSkillMaster(botSkillMaster);
            }

            //Attribute Details
            foreach (BotAttributeMaster botAttributeMasters in botListDetails.BotAttributeMasters)
            {
                BotAttributeMaster botAttributeMaster = new BotAttributeMaster
                {
                    BotID = botId,
                    AttributeName = botAttributeMasters.AttributeName,
                    BotAttributeID = botAttributeMasters.BotAttributeID,
                };
                await _botAttributeMasterRepository.SaveBotAttributeMaster(botAttributeMaster);
            }
        }
    }
}
