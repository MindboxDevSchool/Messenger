using System;

namespace Application.Services.ChatServices
{
    public interface IChatService
    {
        public Guid CreateChannel(Guid ownerId, string channelName, string description);
        public Guid CreateGroup(string groupName);
        public Guid CreatePrivateChat(Guid firstMemberId, Guid secondMemberId);
        public void DeleteChat(Guid chatId);
    }
}