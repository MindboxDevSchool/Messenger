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
            _admins = admins;
        }
        
        public Guid Id { get; }
        public IUser Owner { get; }
        public ChatName Name { get; }
        public ChatDescription Description { get; }
        private readonly IList<IUser> _admins;
        public IReadOnlyList<IUser> Admins => (IReadOnlyList<IUser>) _admins;

        public IReadOnlyCollection<IUser> Members { get; }

        public IReadOnlyCollection<IMessage> Messages { get; }

        public void AddAdmin(IUser user) => _admins.Add(user);

        public void RemoveAdmin(IUser admin) => _admins.Remove(admin);
        public static Group Create(Guid id,
            IUser owner,
            ChatName name,
            ChatDescription description,
            IReadOnlyCollection<IUser> members) =>
            new Group(id, owner, name, description, members, new List<IMessage>(), new List<IUser>());
    }
}