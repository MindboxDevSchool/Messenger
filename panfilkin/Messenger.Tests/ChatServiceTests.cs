using System;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChatServiceTests
    {
        [Test]
        public void Constructor_ValidConstructionData_SuccessfulConstructed()
        {
            // Arrange
            var messageRepository = new MessageRepository();
            var chatRepository = new ChatRepository();
            // Act
            var chatService = new ChatService(chatRepository, messageRepository);

            // Assert
            Assert.AreEqual(messageRepository, chatService.MessageRepository);
            Assert.AreEqual(chatRepository, chatService.ChatRepository);
        }

        [Test]
        public void CreatePrivateChat_ValidData_SuccessfulCreated()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());

            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            // Act
            var chatId = chatService.CreatePrivateChat(user1, user2);
            var chat = chatService.ChatRepository.Load(chatId);

            // Assert
            Assert.True(chat.IsInUserList(user1));
            Assert.True(chat.IsInUserList(user2));
        }

        [Test]
        public void CreateGroupChat_ValidData_SuccessfulCreated()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());

            var user1 = new User(Guid.NewGuid(), "user1");
            // Act
            var chatId = chatService.CreateGroupChat(user1);
            var chat = chatService.ChatRepository.Load(chatId);

            // Assert
            Assert.True(chat.IsInUserList(user1));
        }

        [Test]
        public void CreateChanel_ValidData_SuccessfulCreated()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());

            var user1 = new User(Guid.NewGuid(), "user1");
            // Act
            var chatId = chatService.CreateChanel(user1);
            var chat = chatService.ChatRepository.Load(chatId);

            // Assert
            Assert.True(chat.IsInUserList(user1));
        }

        [Test]
        public void JoinChat_UserWhoCanJoin_SuccessfulJoined()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateChanel(user1);
            var chat = chatService.ChatRepository.Load(chatId);

            // Act
            chatService.JoinChat(chat, user2);

            // Assert
            Assert.True(chat.IsInUserList(user2));
        }

        [Test]
        public void LeaveChat_UserWhoInChat_SuccessfulLeft()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateChanel(user1);
            var chat = chatService.ChatRepository.Load(chatId);
            chatService.JoinChat(chat, user2);

            // Act
            chatService.LeaveChat(chat, user1);

            // Assert
            Assert.False(chat.IsInUserList(user1));
        }

        [Test]
        public void DeleteUser_OwnerDeletesOtherUser_SuccessfulDeleted()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateChanel(user1);
            var chat = chatService.ChatRepository.Load(chatId);
            chatService.JoinChat(chat, user2);

            // Act
            chatService.DeleteUser(chat, user1, user2);

            // Assert
            Assert.False(chat.IsInUserList(user2));
        }

        [Test]
        public void SendMessage_ValidData_SuccessfulSent()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateGroupChat(user1);
            var chat = chatService.ChatRepository.Load(chatId);
            chatService.JoinChat(chat, user2);

            // Act
            var messageId = chatService.SendMessage(chat, user1, "some text");
            var message = chatService.MessageRepository.Load(messageId);

            // Assert
            Assert.True(chat.IsInMessageList(message));
        }

        [Test]
        public void DeleteMessage_ValidData_SuccessfulDeleted()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateGroupChat(user1);
            var chat = chatService.ChatRepository.Load(chatId);
            chatService.JoinChat(chat, user2);
            var messageId = chatService.SendMessage(chat, user1, "some text");
            var message = chatService.MessageRepository.Load(messageId);

            // Act
            chatService.DeleteMessage(user1, message);
            // Assert
            Assert.False(chat.IsInMessageList(message));
        }

        [Test]
        public void EditMessage_ValidData_SuccessfulEdited()
        {
            // Arrange
            var chatService = new ChatService(new ChatRepository(), new MessageRepository());
            var user1 = new User(Guid.NewGuid(), "user1");
            var user2 = new User(Guid.NewGuid(), "user2");
            var chatId = chatService.CreateGroupChat(user1);
            var chat = chatService.ChatRepository.Load(chatId);
            chatService.JoinChat(chat, user2);
            var messageId = chatService.SendMessage(chat, user1, "some text");
            var message = chatService.MessageRepository.Load(messageId);

            // Act
            chatService.EditMessage(user1, message, "new text");
            // Assert
            Assert.True(chat.IsInMessageList(message));
            Assert.AreEqual("new text", message.Text);
        }
    }
}