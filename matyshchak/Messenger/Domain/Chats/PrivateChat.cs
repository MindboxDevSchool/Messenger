using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class PrivateChat : IPrivateChat
    {
        private PrivateChat(Guid id,
            IReadOnlyCollection<IUser> members,
            IReadOnlyCollection<IMessage> messages)
        {
            Id = id;
            Members = members;
            Messages = messages;
        }
        
        public Guid Id { get; }
        public IReadOnlyCollection<IUser> Members { get; }
        public IReadOnlyCollection<IMessage> Messages { get; }

        public static PrivateChat Create(Guid chatId,
            IReadOnlyCollection<IUser> members) =>
            new PrivateChat(chatId, members, new List<IMessage>());
    }
}