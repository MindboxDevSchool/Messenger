using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class Channel : IChannel
    {
        private Channel(Guid id,
            IUser owner,
            ChatName name,
            ChatDescription description,
            IReadOnlyCollection<IUser> subscribers,
            IReadOnlyCollection<IMessage> messages)
        {
            Id = id;
            Name = name;
            Members = subscribers;
            Messages = messages;
            Owner = owner;
            Description = description;
        }

        public Guid Id { get; }

        public ChatName Name { get; }

        public IReadOnlyCollection<IUser> Members { get; }

        public IReadOnlyCollection<IMessage> Messages { get; }

        public IUser Owner { get; }
        public ChatDescription Description { get; }

        public static Channel Create(
            Guid id,
            IUser owner,
            ChatName name,
            ChatDescription description, 
            IReadOnlyCollection<IUser> subscribers) =>
            new Channel(id, owner, name, description, subscribers, new List<IMessage>());
    }
}