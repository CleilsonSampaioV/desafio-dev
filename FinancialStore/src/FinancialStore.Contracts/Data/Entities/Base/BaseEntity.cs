namespace FinancialStore.Contracts.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
