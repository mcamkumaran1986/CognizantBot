using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public class BotListingService : IBotListingService
    {
        private readonly IBotMasterRepository _botMasterRepository;
        private readonly IBotSkillMasterRepository _botSkillMasterRepository;
        private readonly IBotAttributeMasterRepository _botAttributeMasterRepository;
        private readonly IBotIntendMasterRepository _botIntendMasterRepository;

        public BotListingService(
                                                IBotMasterRepository botMasterRepository,
                                                IBotSkillMasterRepository botSkillMasterRepository,
                                                IBotAttributeMasterRepository botAttributeMasterRepository,
                                                IBotIntendMasterRepository botIntendMasterRepository)
        {
            _botMasterRepository = botMasterRepository;
            _botSkillMasterRepository = botSkillMasterRepository;
            _botAttributeMasterRepository = botAttributeMasterRepository;
            _botIntendMasterRepository = botIntendMasterRepository;
        }

        public BotListing GetBotDetails()
        {
            BotListing botListing = new BotListing
            {
                BotMasters = _botMasterRepository.GetBotMaster()
            };
            return botListing;
        }
    }
}
