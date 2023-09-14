using FinancialStore.Contracts.Data.Repositories;
using FinancialStore.Contracts.Data.Transactions;
using FinancialStore.Infra.Data.Repositories;
using FinancialStore.Migrations;

namespace FinancialStore.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IFinancialTransactionRepository FinancialTransactionRepository => new FinancialTransactionRepository(_context);
        public IFinancialTransactionTypeRepository FinancialTransactionTypeRepository => new FinancialTransactionTypeRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}