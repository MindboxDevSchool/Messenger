using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class Group : IGroup
    {
        private Group(Guid id,
            IUser owner,
            ChatName name,
            ChatDescription description,
            IReadOnlyCollection<IUser> members,
            IReadOnlyCollection<IMessage> messages,
            IList<IUser> admins)
        {
            Id = id;
            Owner = owner;
            Name = name;
            Description = description;
            Members = members;
            Messages = messages;
            Admins = admins;
        }
        
        public Guid Id { get; }
        public IUser Owner { get; }
        public ChatName Name { get; }
        public ChatDescription Description { get; }
        public IList<IUser> Admins { get; }
        public IReadOnlyCollection<IUser> Members { get; }
        public IReadOnlyCollection<IMessage> Messages { get; }

        public static Group Create(Guid id,
            IUser owner,
            ChatName name,
            ChatDescription description,
            IReadOnlyCollection<IUser> members) =>
            new Group(id, owner, name, description, members, new List<IMessage>(), new List<IUser>());
    }
}