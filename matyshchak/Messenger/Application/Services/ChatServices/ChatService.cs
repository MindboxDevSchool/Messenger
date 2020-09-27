using System;

namespace Application.Services.ChatServices
{
    public class ChatService : IChatService
    {
        public Guid CreateChannel(Guid ownerId, string channelName, string description)
        {
            throw new NotImplementedException();
        }

        public Guid CreateGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public Guid CreatePrivateChat(Guid firstMemberId, Guid secondMemberId)
        {
            throw new NotImplementedException();
        }

        public void DeleteChat(Guid chatId)
        {
            throw new NotImplementedException();
        }
    }
}