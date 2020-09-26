using System;

namespace Messenger.Domain
{
    public class Chanel : IChanel
    {
        public Chanel(String id, string name, IUser user)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public String Id { get; }
        public string Name { get; set; }
        public IUser User { get; }
    }
}