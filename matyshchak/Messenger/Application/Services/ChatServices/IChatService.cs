﻿using System;
 using Domain.Chats;

 namespace Application.Services.ChatServices
{
    public interface IChatService
    {
        public Guid CreateChannel(ChatName channelName, ChatDescription description);
        public Guid CreateGroup(ChatName groupName, ChatDescription description);
        public Guid CreatePrivateChat(Guid otherUserId);
        public void DeleteChat(Guid chatId);
    }
}