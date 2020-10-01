using System;
using System.Collections.Generic;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public class FileRepo<T> : IRepo<T>
    {
        private readonly string _filename;
        private readonly List<T> _items;

        public IEnumerable<T> Items => _items;

        public FileRepo(string filename)
        {
            _filename = filename;
            _items = FileIO.Load<T>(_filename);
        }
        
        public void Add(T item)
        {
            _items.Add(item);
            FileIO.Dump<T>(_filename, _items);
        }

        public int Remove(Predicate<T> predicate)
        {
            int count = _items.RemoveAll(predicate);
            FileIO.Dump<T>(_filename, _items);
            return count;
        }

        public int Apply(Predicate<T> predicate, Action<T> action)
        {
            int count = 0;
            foreach (T item in _items)
            {
                if (predicate.Invoke(item))
                {
                    action.Invoke(item);
                    ++count;
                }
            }
            FileIO.Dump<T>(_filename, _items);
            return count;
        }
    }
}
