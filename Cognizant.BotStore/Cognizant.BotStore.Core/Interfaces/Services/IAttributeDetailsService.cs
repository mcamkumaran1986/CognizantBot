using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Core
{
    public interface IAttributeDetailsService
    {
        Task<List<AttributeDetails>> GetAttributeDetails();
        Task<int> SaveAttributeDetails(AttributeDetails attributeDetails);
    }
}
