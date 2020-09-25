using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IUser
    {
        public Guid Id { get; }
        public string Username { get; }
    }
}