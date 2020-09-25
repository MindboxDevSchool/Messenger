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
    public class MessageServiceTests
    {
        [Test]
        public void SendMessage_MessageIsSentSuccessfully()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someName", ChatTypes.Channel);
            MessageService messageService = new MessageService(chat, userRepository);

            messageService.SendMessage(userAdmin.Id, "Some message");

            Assert.AreEqual("Some message", chat.Messages.First().Content);
        }
        
        [Test]
        public void DeleteMessage_MessageIsInChat_False()
        {
            IChatRepository chatRepository = new ChatRepository();
            IUserRepository userRepository = new UserRepository();
            IUser userAdmin = new User("Admin", "password");
            userRepository.SaveUser(userAdmin);
            ChatService chatService = new ChatService(chatRepository, userRepository, userAdmin);
            IChat chat = chatService.CreateChat(userAdmin, "someName", ChatTypes.Channel);
            MessageService messageService = new MessageService(chat, userRepository);

            messageService.SendMessage(userAdmin.Id, "Some message");
            var message = chat.Messages.First();
            messageService.DeleteMessage(userAdmin.Id, message.Id);
            
            Assert.IsFalse(chat.Messages.Contains(message));
        }
    }
}