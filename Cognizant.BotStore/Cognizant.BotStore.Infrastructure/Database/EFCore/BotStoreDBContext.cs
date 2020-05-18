using Cognizant.BotStore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.BotStore.Infrastructure
{
    public class BotStoreDBContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        public BotStoreDBContext(DbContextOptions<BotStoreDBContext> options) : base(options)
        {

        }
      
        public virtual DbSet<TeamDetails> TeamDetails { get; set; }
        public virtual DbSet<BotMaster> BotMaster { get; set; }
        public virtual DbSet<BotSkillMaster> BotSkillMaster { get; set; }
        public virtual DbSet<BotAttributeMaster> BotAttributeMaster { get; set; }
        public virtual DbSet<BotIntendMaster> BotIntendMaster { get; set; }
        public virtual DbSet<BotAssignment> BotAssignment { get; set; }
        public virtual DbSet<AttributeDetails> AttributeDetails { get; set; }
        public virtual DbSet<IntendDetails> IntendDetails { get; set; }
        public virtual DbSet<BotImageDetails> BotImageDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public int SaveChanges(int auditUserId)
        {

            var addedAuditedEntities = ChangeTracker.Entries<BaseEntity>()
              .Where(p => p.State == EntityState.Added)
              .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<BaseEntity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var now = DateTime.Now;

            foreach (var added in addedAuditedEntities)
            {
                added.CreatedTime = now;
                added.CreatedBy = added.CreatedBy > 0 ? added.CreatedBy : auditUserId;
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.ModifiedTime = now;
                modified.ModifiedBy = auditUserId;
            }

            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(int auditUserId, CancellationToken cancellationToken = default)
        {
            var addedAuditedEntities = ChangeTracker.Entries<BaseEntity>()
              .Where(p => p.State == EntityState.Added)
              .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<BaseEntity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var now = DateTime.Now;

            foreach (var added in addedAuditedEntities)
            {
                added.CreatedTime = now;
                added.CreatedBy = added.CreatedBy > 0 ? added.CreatedBy : auditUserId;
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.ModifiedTime  = now;
                modified.ModifiedBy = auditUserId;
            }

            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadUncommitted);//.ConfigureAwait(false);  This should be synchronous 
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task CommitTransactionAsync(int auditUserId)
        {
            try
            {
                await SaveChangesAsync(auditUserId).ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                    _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadUncommitted);//.ConfigureAwait(false);  This should be synchronous 
                }
            }
        }
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}
