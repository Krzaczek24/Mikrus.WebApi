using Microsoft.EntityFrameworkCore.Storage;

namespace Krzaq.Mikrus.Database
{
    public interface ITransactionManager
    {
        ValueTask<IDbContextTransaction> BeginTransaction();
        ValueTask CommitTransaction();
        ValueTask RollbackTransaction();
    }

    internal class TransactionManager(AppDbContext context) : ITransactionManager
    {
        public async ValueTask<IDbContextTransaction> BeginTransaction() => await context.Database.BeginTransactionAsync();
        public async ValueTask CommitTransaction() => await context.Database.CommitTransactionAsync();
        public async ValueTask RollbackTransaction() => await context.Database.RollbackTransactionAsync();
    }
}
