using System;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(Guid id);
        void Update(T entity);
        void Delete(Guid id);
    }
}