using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public Guid Id { get; }
        public string Name { get; }

        public string Phone { get; }

        public User(Guid id, string name, string phone, Dictionary<Guid, ChatRole> availableChats)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            _availableChats = availableChats;
        }

        public bool HaveAccessTo(Guid chatId, AccessType accessType)
        {
            if (!_availableChats.TryGetValue(chatId, out var chatRole))
            {
                throw new ChatNotFoundException(chatId);
            }
            
            return chatRole.GetAccessFor(accessType);
        }

        private Dictionary<Guid, ChatRole> _availableChats;
    }
}