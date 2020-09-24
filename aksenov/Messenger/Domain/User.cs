using System;
using System.Collections.Generic;
using Messenger.Exceptions;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid Id { get; }
        public string Name { get; }

        public string Phone { get; }

        public Dictionary<Guid, ChatRole> AvailableChats { get; }

        public User(Guid id, string name, string phone, Dictionary<Guid, ChatRole> availableChats)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            AvailableChats = availableChats;
        }

        public bool HaveAccessTo(Guid chatId, AccessType accessType)
        {
            if (!AvailableChats.TryGetValue(chatId, out var chatRole))
            {
                throw new ChatNotFoundException(chatId);
            }
            
            return chatRole.GetAccessFor(accessType);
        }
    }
}