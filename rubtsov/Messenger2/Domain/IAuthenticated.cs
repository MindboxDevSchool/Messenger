using System;
using System.Collections.Generic;

namespace Messenger2.Domain
{
    public interface IAuthenticated
    {
        public Guid Id { get; }
        public IUser Admin { get; set; }
        public HashSet<IUser> Users { get; }
    }
}