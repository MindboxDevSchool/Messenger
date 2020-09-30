using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IRepo<T>
    {
        IEnumerable<T> Items { get; }
        void AddItem(T item);
    }
}
