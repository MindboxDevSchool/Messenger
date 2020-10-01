using System;
using System.Collections.Generic;
using System.Linq;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public class InMemoryRepo<T> : IRepo<T>
    {
        private readonly List<T> _items;

        public IEnumerable<T> Items => _items;

        public InMemoryRepo() : this(new T[0]) { }

        public InMemoryRepo(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            _items = items.ToList();
        }

        public void Add(T item) => _items.Add(item);
        
        public int Remove(Predicate<T> predicate) => _items.RemoveAll(predicate);

        public int Apply(Predicate<T> predicate, Action<T> action)
        {
            List<T> items = _items.Where(predicate.Invoke).ToList();
            items.ForEach(action);
            return _items.Count;
        }
    }
}
