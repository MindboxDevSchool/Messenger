using System;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChatService
    {
        IChat Create(ChatType chatType, string name, Guid creatorId);
        void Delete(Guid chatId);
        void AddMember(Guid chatId, Guid userId);
        void RemoveMember(Guid chatId, Guid userId);
        void ChangeMemberRole(Guid chatId, Guid userId, RoleType roleType);
    }
}