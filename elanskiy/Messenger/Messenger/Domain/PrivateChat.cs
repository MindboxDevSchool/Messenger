using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class PrivateChat : IPrivateChat
    {
        private Guid[] _users;
        
        public Guid Id { get; }
        
        public Guid[] Users
        {
            get => _users;
            private set
            {
                if (value == null || value.Length != 2)
                    throw new ArgumentException("In private chat must be 2 users!");
                _users = value;
            }
        }

        public DateTime CreatedOn { get; }

        public PrivateChat(Guid id, Guid[] users)
        {
            Id = id;
            Users = users;
            CreatedOn = DateTime.Now;
        }
    }
}