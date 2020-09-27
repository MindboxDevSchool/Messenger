using System;
using Domain.Chats;
using Domain.Repositories;

namespace Application.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public Guid CreateChannel(Guid ownerId, string channelName, string description)
        {
            var owner = _userRepository.GetUser(ownerId);
            var id = new Guid();
            var chat = Channel.Create(id, owner);
            _chatRepository.AddChat(chat);
            return id;
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