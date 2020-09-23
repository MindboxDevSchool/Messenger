using System;
using System.Collections.Generic;

namespace Messanger.Domain.ChatModel
{
    public interface IGroupChat : IChat
    {
        // Owner and Admin are IUser entities
        public Guid OwnerId { get; }
        public IEnumerable<Guid> AdminIdCollection { get; }

        protected bool CheckIfUserCanEditMemberIdCollection(Guid userId);
        public void AddUser(Guid userId);
        public void RemoveUser(Guid userId);
        
        protected bool CheckIfUserCanSendMessage(Guid user);
        protected bool CheckIfUserCanEditMessage(Guid user);
        protected bool CheckIfUserCanDeleteMessage(Guid user);
    }
}