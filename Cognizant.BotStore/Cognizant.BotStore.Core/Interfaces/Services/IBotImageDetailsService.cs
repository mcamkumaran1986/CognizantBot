using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IBotImageDetailsService
    {
        Task<List<BotImageDetails>> GetBotImageNames();
        Task<int> SaveBotImageDetails(BotImageDetails botImageDetails);
    }
}
