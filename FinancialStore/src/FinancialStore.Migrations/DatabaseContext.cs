using FinancialStore.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialStore.Migrations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<FinancialTransactionType> FinancialTransactionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialTransaction>()
                .HasOne<FinancialTransactionType>()
                .WithMany(e => e.FinancialTransactions)
                .HasForeignKey(e => e.FinancialTransactionTypeId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FinancialTransactionType>().HasIndex(e => e.Type).IsUnique();

            modelBuilder.Entity<FinancialTransactionType>()
                .HasData(
                new FinancialTransactionType
                {
                    Type = 1,
                    Description = "Débito",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 2,
                    Description = "Boleto",
                    NatureOperationType = NatureOperationType.Expense,
                },
                new FinancialTransactionType
                {
                    Type = 3,
                    Description = "Financiamento",
                    NatureOperationType = NatureOperationType.Expense,
                },
                new FinancialTransactionType
                {
                    Type = 4,
                    Description = "Crédito",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 5,
                    Description = "Recebimento Empréstimo",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 6,
                    Description = "Vendas",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 7,
                    Description = "Recebimento TED",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 8,
                    Description = "Recebimento DOC",
                    NatureOperationType = NatureOperationType.Income,
                },
                new FinancialTransactionType
                {
                    Type = 9,
                    Description = "Aluguel",
                    NatureOperationType = NatureOperationType.Expense,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}