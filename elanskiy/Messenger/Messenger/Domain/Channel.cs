using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Channel : IChannel
    {
        public Guid Id { get; }
        
        public string Name { get; }

        public DateTime CreatedOn { get; }

        public List<Guid> Admins { get; set; } = new List<Guid>();
        
        public List<Guid> Users { get; set; } = new List<Guid>();

        public Channel(Guid id, Guid admin, string name)
        {
            Id = id;
            Name = name;
            Admins.Add(admin);
            CreatedOn = DateTime.UtcNow;
        }
    }
}