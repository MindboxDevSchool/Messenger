using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class PrivateChatTests
    {
        [Test]
        public void Constructor_ValidData_SuccessfulConstructed()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();

            // Act
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            // Assert
            Assert.AreEqual(chatId, chat.Id);
            Assert.True(chat.IsInOwnerList(userOwnerOfChat));
            Assert.True(chat.IsInUserList(userInChat));
        }

        [Test]
        public void DeleteMessage_OwnerOfMessage_SuccessfulDeleted()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);

            // Act
            chat.DeleteMessage(userInChat, message);

            // Assert
            Assert.True(chat.MessageList.Count == 0);
        }

        [Test]
        public void DeleteMessage_NotOwnerOfMessage_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.DeleteMessage(userOwnerOfChat, message));

            // Assert
            Assert.True(exception.Message == "This user can't delete this message!");
        }

        [Test]
        public void DeleteMessage_NotOwnerMessage_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.DeleteMessage(userOwnerOfChat, message));

            // Assert
            Assert.True(exception.Message == "This user can't delete this message!");
        }

        [Test]
        public void DeleteMessage_NoUserInChat_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteMessage(userNotInChat, message));

            // Assert
            Assert.True(exception.Message == "This user not found in this chat!");
        }

        [Test]
        public void DeleteMessage_MessageNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);
            chat.DeleteMessage(userInChat, message);

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteMessage(userInChat, message));

            // Assert
            Assert.True(exception.Message == "This message not found in this chat!");
        }

        [Test]
        public void AddUser_AnyUser_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.AddUser(userNotInChat));

            // Assert
            Assert.True(exception.Message == "This user can't join private chat!");
        }

        [Test]
        public void DeleteUser_DeleteHimself_SuccessDeleted()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            // Act
            chat.DeleteUser(userInChat, userInChat);

            // Assert
            Assert.False(chat.IsInUserList(userInChat));
        }

        [Test]
        public void DeleteUser_DeleteOtherUser_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.DeleteUser(userOwnerOfChat, userInChat));

            // Assert
            Assert.True(exception.Message == "This user can't delete another user!");
        }

        [Test]
        public void DeleteUser_NoInChatUserTryToDelete_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new PrivateChat(chatId, ownerList, userList, messageList);

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteUser(userNotInChat, userInChat));

            // Assert
            Assert.True(exception.Message == "This user not found in this chat!");
        }
    }
}