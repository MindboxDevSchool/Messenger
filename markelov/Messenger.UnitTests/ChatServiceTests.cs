using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Messenger.Application;
using Messenger.Domain;
using Messenger.Infrastructure;
using NUnit.Framework;

namespace Messenger.UnitTests
{
    [TestFixture]
    public class ChatServiceTests
    {
        public ChatService SetupChatService()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();

            IEnumerable<IUser> admins = new List<IUser>();
            IEnumerable<IUser> users = new List<IUser>();

            IUser userAdmin = new User("Admin", "password");
            IUser user = new User("SimpleUser", "password");
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            return chatService;
        }

        [Test]
        public void UserCreatesChannelChat_ChatCreationIsSuccessful()
        {
            IUser userAdmin = new User("Admin", "password");
            ChatServiceTests setUpClass = new ChatServiceTests();
            ChatService chatService = setUpClass.SetupChatService();
            
            IChat newChannelChat = chatService.CreateChat(userAdmin, "new chat", ChatTypes.Channel);
            
            Assert.IsTrue(newChannelChat.Users.Contains(userAdmin));
        }

        [Test]
        public void UserAddsUserToChat_CheckIfUserIsAdded_ChatHasTwoUsers()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someCHat", ChatTypes.Channel);
            IUser newUser = new User("some user", "dsaf");
            userRepository.SaveUser(newUser);

            chatService.AddUserToChat(userAdmin, newUser.Id, chat.Id);
            
            Assert.AreEqual(2, chat.Users.Count());
        }
        
        [Test]
        public void AdminRemovesUserFromChat_CheckIfUserIsInChat_False()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someCHat", ChatTypes.Channel);
            IUser newUser = new User("some user", "dsaf");
            userRepository.SaveUser(newUser);

            chatService.AddUserToChat(userAdmin, newUser.Id, chat.Id);
            chatService.RemoveUserFromChat(userAdmin, newUser.Id, chat.Id);
            
            Assert.IsFalse(chat.Users.Contains(newUser));
        }
        
        [Test]
        public void AdminMakesUserAdmin_CheckIfUserBecomesAdmin_True()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someCHat", ChatTypes.Channel);
            IUser newUser = new User("some user", "dsaf");
            userRepository.SaveUser(newUser);

            chatService.AddUserToChat(userAdmin, newUser.Id, chat.Id);
            chatService.MakeUserAdmin(userAdmin, newUser.Id, chat.Id);
            
            Assert.IsTrue(chat.Admins.Contains(newUser));
        }
        
        [Test]
        public void AdminRemovesAdminStatusFromUser_CheckIfUserIsAdmin_False()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someCHat", ChatTypes.Channel);
            IUser newUser = new User("some user", "dsaf");
            userRepository.SaveUser(newUser);

            chatService.AddUserToChat(userAdmin, newUser.Id, chat.Id);
            chatService.MakeUserAdmin(userAdmin, newUser.Id, chat.Id);
            chatService.RemoveUserFromAdmins(userAdmin, newUser.Id, chat.Id);
            
            Assert.IsFalse(chat.Admins.Contains(newUser));
        }
    }
}