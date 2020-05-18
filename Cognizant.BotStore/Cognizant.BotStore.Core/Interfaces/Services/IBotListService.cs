using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotListService
    {
        Task<BotListing> GetBotMaster();
        Task<BotListDetails> GetBotMasterById(int botId);
        Task SaveBotMaster(BotListDetails botListDetails);
    }
}
