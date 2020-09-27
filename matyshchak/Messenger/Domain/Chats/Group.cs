using System;
using System.Collections.Generic;
using Domain.Message;
using Domain.User;

namespace Domain.Chats
{
    public class Group : IGroup
    {
        public Group(Guid id, IEnumerable<IUser> members, IEnumerable<IMessage> messages, IEnumerable<IUser> admins)
        {
            Id = id;
            Members = members;
            Messages = messages;
            Admins = admins;
        }

        public Guid Id { get; }
        public IEnumerable<IUser> Members { get; }
        public IEnumerable<IMessage> Messages { get; }
        public IEnumerable<IUser> Admins { get; }
        public void PromoteToAdmin(IUser user)
        {
            throw new NotImplementedException();
        }

        public void DemoteFromAdmin(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}