﻿namespace FinancialStore.Contracts.Data.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        int Count();
    }
}
