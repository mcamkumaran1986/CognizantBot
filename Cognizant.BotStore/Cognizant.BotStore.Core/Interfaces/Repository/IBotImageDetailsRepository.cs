using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotImageDetailsRepository
    {
        Task<List<BotImageDetails>> GetBotImageNames();
        Task<int> SaveBotImageDetails(BotImageDetails botImageDetails);
    }
}
