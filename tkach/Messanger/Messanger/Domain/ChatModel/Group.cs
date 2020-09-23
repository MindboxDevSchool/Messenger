using System;
using System.Collections.Generic;
using Messanger.Domain.MessageModel;

namespace Messanger.Domain.ChatModel
{
    public class Group : IGroupChat
    {
        public string Name { get; }
        public Guid Id { get; }
        public IEnumerable<Guid> MemberIdCollection { get; }
        public IEnumerable<IMessage> MessageCollection { get; }
        public void SendMessage(IMessage message)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(Guid oldmessageId, IMessage message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Guid messageId)
        {
            throw new NotImplementedException();
        }

        public Guid OwnerId { get; }
        public IEnumerable<Guid> AdminIdCollection { get; }
        bool IGroupChat.CheckIfUserCanEditMemberIdCollection(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        bool IGroupChat.CheckIfUserCanSendMessage(Guid user)
        {
            throw new NotImplementedException();
        }

        bool IGroupChat.CheckIfUserCanEditMessage(Guid user)
        {
            throw new NotImplementedException();
        }

        bool IGroupChat.CheckIfUserCanDeleteMessage(Guid user)
        {
            throw new NotImplementedException();
        }
    }
}