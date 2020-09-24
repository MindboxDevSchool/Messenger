using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Application
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository, MessengerSettings messengerSettings)
        {
            _userRepository = userRepository;
            _messengerSettings = messengerSettings;
        }

        public void CreateNewUser(string name, string phone)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (phone == null) throw new ArgumentNullException(nameof(phone));

            var userId = Guid.NewGuid();
            var availableRoles = new Dictionary<Guid, ChatRole>();
            var user = new User(userId, name, phone, availableRoles);

            _userRepository.Save(user);
        }

        public void AddChatTo(Guid userId, Guid chatId, RoleType roleType)
        {
            var user = _userRepository.GetBy(userId);
            var availableChats = user.AvailableChats;
            var chatRole = _messengerSettings.ChatRoles[roleType];
            availableChats.Add(chatId, chatRole);
            _userRepository.Update(user);
        }

        public void ChangeChatRoleTo(Guid userId, Guid chatId, RoleType roleType)
        {
            var user = _userRepository.GetBy(userId);
            var availableChats = user.AvailableChats;
            var chatRole = _messengerSettings.ChatRoles[roleType];
            availableChats[chatId] = chatRole;
            _userRepository.Update(user);
        }

        public void DeleteChatTo(IEnumerable<IUser> chatUsers, Guid chatId)
        {
            var users = new List<IUser>(chatUsers);
            foreach (var user in users)
                user.AvailableChats.Remove(chatId);
            _userRepository.Update(users);
        }

        public void DeleteChatTo(IUser user, Guid chatId)
        {
            user.AvailableChats.Remove(chatId);
            _userRepository.Update(user);
        }

        private readonly IUserRepository _userRepository;
        private readonly MessengerSettings _messengerSettings;
    }
}