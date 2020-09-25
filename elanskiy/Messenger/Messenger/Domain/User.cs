using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User
    {
        public Guid Id { get; }
        public Credentials Credentials { get; }
        
        public User(Guid id, Credentials credentials)
        {
            Id = id;
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }
    }
}