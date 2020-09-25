using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class GroupChat : IGroupChat
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public List<Guid> Users { get; set; } = new List<Guid>();

        public List<Guid> Admins { get; set; } = new List<Guid>();
        
        public DateTime CreatedOn { get; }

        public GroupChat(Guid groupId, Guid adminId, string name)
        {
            Id = groupId;
            Name = name;
            Admins.Add(adminId);
            CreatedOn = DateTime.UtcNow;
        }
    }
}