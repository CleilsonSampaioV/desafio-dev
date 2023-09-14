using FinancialStore.Contracts.Data.Entities;
using FinancialStore.Contracts.Data.Repositories;
using FinancialStore.Infra.Data.Repositories.Generic;
using FinancialStore.Migrations;
using Microsoft.EntityFrameworkCore;

namespace FinancialStore.Infra.Data.Repositories
{
    public class FinancialTransactionRepository : Repository<FinancialTransaction>, IFinancialTransactionRepository
    {
        private readonly DatabaseContext _databaseContext;
        public FinancialTransactionRepository(DatabaseContext context) : base(context)
        {
            _databaseContext = context;
        }

        public IEnumerable<FinancialTransaction> GetAllWithFinancialTransactionType()
        {
          return  _databaseContext.FinancialTransactions.Include(e=>e.FinancialTransactionType).ToList();
        }
    }
}