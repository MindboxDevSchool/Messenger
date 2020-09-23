using System;
using System.Collections.Generic;

namespace Messanger.Domain.UserModel
{
    public interface IUser
    {
        public Guid Id { get; }
        public string Login { get; }
        public string TelephoneNumber { get; }
        public IEnumerable<Guid> ChatIdCollection { get; }
    }
}