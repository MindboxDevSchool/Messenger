using System;
using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IRepo<T>
    {
        IEnumerable<T> Items { get; }
        void Add(T item);
        int Remove(Predicate<T> predicate);
        int Apply(Predicate<T> predicate, Action<T> action);
    }
}
