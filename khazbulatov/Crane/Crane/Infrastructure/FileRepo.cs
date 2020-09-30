using System.Collections.Generic;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public class FileRepo<T> : IRepo<T>
    {
        private readonly string _filename;
        private readonly IList<T> _items;

        public IEnumerable<T> Items => _items;

        public FileRepo(string filename)
        {
            _filename = filename;
            _items = FileIO.Load<T>(_filename);
        }
        
        public void AddItem(T item)
        {
            _items.Add(item);
            FileIO.Dump<T>(_filename, _items);
        }
    }
}
