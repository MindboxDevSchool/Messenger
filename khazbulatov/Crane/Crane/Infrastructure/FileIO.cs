using System.Collections.Generic;
using System.IO;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public static class FileIO
    {
        public static IList<T> Load<T>(string filename)
        {
            IList<T> items = new List<T>();
            using StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string representation = reader.ReadLine();
                Maybe<T> item = Repr<T>.Parse(representation);
                if (item is Maybe<T>.Some someItem) items.Add(someItem.Value);
            }
            return items;
        }
        
        public static void Dump<T>(string filename, IEnumerable<T> items)
        {
            using StreamWriter writer = new StreamWriter(filename);
            foreach (T item in items)
            {
                string representation = Repr<T>.Render(item);
                writer.WriteLine(representation);
            }
        }
    }
}
