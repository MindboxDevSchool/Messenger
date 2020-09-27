using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class Channel : IChannel
    {
        private Channel(Guid id, IUser owner, IEnumerable<IUser> members, IEnumerable<IMessage> messages)
        {
            Id = id;
            Owner = owner;
            Members = members;
            Messages = messages;
        }

        public Guid Id { get; }
        public IUser Owner { get; }
        public IEnumerable<IUser> Members { get; }
        public IEnumerable<IMessage> Messages { get; }

        public static Channel Create(Guid id, IUser owner)
        {
            return new Channel(
                id,
                owner,
                new List<IUser>(),
                new List<IMessage>());
        }
    }
}