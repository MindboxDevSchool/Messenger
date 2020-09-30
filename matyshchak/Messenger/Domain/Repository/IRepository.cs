using System;

namespace Domain.Repository
{
    public interface IRepository<T>
    { 
        T Find(Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}