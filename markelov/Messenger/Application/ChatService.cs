using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class ChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUser _userRequestingService;
        public ChatService(IChatRepository repository, IUserRepository userRepository, IUser user)
        {
            _chatRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userRequestingService = user ?? throw new ArgumentNullException(nameof(user));
        }
        
        public IChat CreateChat(IUser user, string chatName, ChatTypes chatType)
        {
            IChat newChat;
            List<IUser> initialUserList = new List<IUser> {user};
            switch (chatType)
            {
                case ChatTypes.Channel:
                    newChat = new Channel(
                        chatName, 
                        initialUserList, 
                        initialUserList, 
                        new List<IMessage>(),
                        chatType);
                    break;
                case ChatTypes.Dialogue:
                    newChat = new Dialogue(
                        chatName, 
                        initialUserList, 
                        initialUserList, 
                        new List<IMessage>(),
                        chatType);
                    break;
                case ChatTypes.Group:
                    newChat = new GroupChat(
                        chatName, 
                        initialUserList, 
                        initialUserList, 
                        new List<IMessage>(),
                        chatType);
                    break;
                default:
                    newChat = null;
                    break;
            }
            _chatRepository.SaveChat(newChat);
            return newChat;
        }

        public void AddUserToChat(IUser userRequestingService, Guid userId, Guid chatId)
        {
            var chat = _chatRepository.GetChat(chatId);
            if (chat == null) return;
            if (chat.ChatType == ChatTypes.Dialogue && chat.Users.Count() >= 2)
            {
                throw new Exception("Dialogue Chat can't have more than two people!");
            }

            if (chat.Users.Contains(userRequestingService))
            {
                var user = _userRepository.Load(userId);
                if (user == null) return;
                
                var tempChatUsers = chat.Users.ToList();
                tempChatUsers.Add(user);
                chat.Users = tempChatUsers;

                var tempUserChats = user.Chats.ToList();
                tempUserChats.Add(chat);
                user.Chats = tempUserChats;
            }
        }
        
        public void RemoveUserFromChat(IUser userRequestingService, Guid userId, Guid chatId)
        {
            var chat = _chatRepository.GetChat(chatId);
            if (chat != null && (chat.Admins.Contains(userRequestingService) || userRequestingService.Id == userId))
            {
                if (chat.ChatType == ChatTypes.Dialogue)
                {
                    _chatRepository.DeleteChat(chatId);
                    return;
                }
                var user = _userRepository.Load(userId);
                if (user == null) return;
                
                var tempChatUsers = chat.Users.ToList();
                tempChatUsers.Remove(user);
                chat.Users = tempChatUsers;

                var tempUserChats = user.Chats.ToList();
                tempUserChats.Remove(chat);
                user.Chats = tempUserChats;
            }
        }

        public void MakeUserAdmin(IUser userRequestingService, Guid userId, Guid chatId)
        {
            var chat = _chatRepository.GetChat(chatId);
            if (chat != null && chat.Admins.Contains(userRequestingService))
            {
                var user = _userRepository.Load(userId);
                if (user == null) return;
                
                var tempChatAdmins = chat.Users.ToList();
                tempChatAdmins.Add(user);
                chat.Admins = tempChatAdmins;
            }
        }
        
        public void RemoveUserFromAdmins(IUser userRequestingService, Guid userId, Guid chatId)
        {
            var chat = _chatRepository.GetChat(chatId);
            if (chat != null && chat.Admins.Contains(userRequestingService))
            {
                var user = _userRepository.Load(userId);
                if (user == null) return;
                
                var tempChatAdmins = chat.Users.ToList();
                tempChatAdmins.Remove(user);
                chat.Admins = tempChatAdmins;
            }
        }
    }
}