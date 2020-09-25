using System;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class ChatService : IChatService
    {
        public ChatService(IChatFactory chatFactory, IUserRepository userRepository, IChatRepository chatRepository, IUserService userService)
        {
            _chatFactory = chatFactory;
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _userService = userService;
        }

        public IChat Create(ChatType chatType, string name, Guid creatorId)
        {
            var chat = _chatFactory.Create(chatType, name, creatorId);
            var creator = chat.GetMemberBy(creatorId);
            _userService.AddChatTo(creatorId, chat.Id, creator.Role);
            _chatRepository.Save(chat);
            return chat;
        }

        public void Delete(Guid chatId)
        {
            var chat = _chatRepository.GetBy(chatId);
            var chatUsers = chat.Members.Select(member => member.User);
            _userService.DeleteChatTo(chatUsers, chatId);
            _chatRepository.Delete(chatId);
        }

        public void AddMember(Guid chatId, Guid userId)
        {
            var user = _userRepository.GetBy(userId);
            var chat = _chatRepository.GetBy(chatId);
            var member = chat.AddMember(user);
            _userService.AddChatTo(userId, chatId, member.Role);
            _chatRepository.Update(chat);
        }

        public void RemoveMember(Guid chatId, Guid userId)
        {
            var user = _userRepository.GetBy(userId);
            var chat = _chatRepository.GetBy(chatId);
            chat.RemoveMember(userId);
            _userService.DeleteChatTo(user, chatId);
            _chatRepository.Update(chat);
        }

        public void ChangeMemberRole(Guid chatId, Guid userId, RoleType roleType)
        {
            var chat = _chatRepository.GetBy(chatId);
            chat.TryChangeMemberRole(userId, roleType);
            _userService.ChangeChatRoleTo(userId, chatId, roleType);
            _chatRepository.Update(chat);
        }

        private readonly IChatFactory _chatFactory;
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IUserService _userService;
    }
}