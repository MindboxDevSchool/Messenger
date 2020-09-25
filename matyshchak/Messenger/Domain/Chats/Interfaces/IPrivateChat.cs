using System;
using Domain.User;

namespace Domain.Chat
{
    public interface IPrivateChat : IChat
    {
        public Tuple<Guid, Guid> MembersIds { get; }
    }
}