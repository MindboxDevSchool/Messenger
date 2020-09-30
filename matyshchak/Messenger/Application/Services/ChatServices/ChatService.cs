using System;
using System.Collections.Generic;
using Domain.Chats;
using Domain.Repository;
using Domain.User;
using Domain.UserPermissions;
using Domain.UserPermissions.Exceptions;
using Channel = Domain.Chats.Channel;

namespace Application.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly IContext _context;
        private readonly IRepository<IChat> _chatRepository;
        private readonly IRepository<IUser> _userRepository;

        public ChatService(IContext context, IRepository<IChat> chatRepository, IRepository<IUser> userRepository)
        {
            _context = context;
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }
        
        public Guid CreateChannel(ChatName channelName, ChatDescription description)
        {
            var user = _userRepository.Find(_context.CurrentUserId);
            var subscribers = new List<IUser> {user};
            var channelId = new Guid();
            var channel = Channel.Create(channelId, user, channelName, description, subscribers);
            _chatRepository.Add(channel);
            
            return channelId;
        }

        public Guid CreateGroup(ChatName groupName, ChatDescription description)
        {
            var user = _userRepository.Find(_context.CurrentUserId);
            var groupId = new Guid();
            var groupMembers = new List<IUser> {user};
            var group = Group.Create(groupId, user, groupName, description, groupMembers);
            _chatRepository.Add(group);
            
            return groupId;
        }

        public Guid CreatePrivateChat(Guid otherUserId)
        {
            var user = _userRepository.Find(_context.CurrentUserId);
            var otherUser = _userRepository.Find(otherUserId);
            var chatId = new Guid();
            var chatMembers = new List<IUser> {user, otherUser};
            var privateChat = PrivateChat.Create(chatId, chatMembers);
            _chatRepository.Add(privateChat);
            
            return chatId;
        }

        public void DeleteChat(Guid chatId)
        {
            var user = _userRepository.Find(_context.CurrentUserId);
            var chat = _chatRepository.Find(chatId);

            if (chat is PrivateChat privateChat && user.IsMemberOf(privateChat) ||
                chat is IHasOwner chatWithOwner && user.IsOwnerOf(chatWithOwner))
                _chatRepository.Delete(chatId);
            
            throw new NoPermissionToDeleteChatException();
        }
    }
}