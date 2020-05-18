namespace Cognizant.BotStore.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
