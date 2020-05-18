using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IIntendDetailsRepository
    {
        Task<List<IntendDetails>> GetIntendDetails();
        Task<int> SaveIntendDetails(IntendDetails intendDetails);
    }
}
