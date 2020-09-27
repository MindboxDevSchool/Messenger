using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class PrivateChat : IPrivateChat
    {
        public PrivateChat(Guid id, IEnumerable<IUser> members, IEnumerable<IMessage> messages)
        {
            Id = id;
            Members = members;
            Messages = messages;
        }

        public Guid Id { get; }
        public IEnumerable<IUser> Members { get; }
        public IEnumerable<IMessage> Messages { get; }
    }
}