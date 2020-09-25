using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChanelTests
    {
        [Test]
        public void Constructor_ValidConstructionData_SuccessfulConstructed()
        {
            // Arrange
            var userOwner = new User(Guid.NewGuid(), "silkslime");
            var user = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwner};
            var userList = new List<IUser>() {user};
            var messageList = new List<IMessage>();

            // Act
            var chat = new Chanel(chatId, ownerList, userList, messageList);

            // Assert
            Assert.AreEqual(chatId, chat.Id);
            Assert.True(chat.IsInOwnerList(userOwner));
            Assert.True(chat.IsInUserList(user));
        }

        [Test]
        public void AddMessage_OwnerAdds_SuccessfulAdded()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new Chanel(chatId, ownerList, userList, messageList);

            var message = new Message(userOwnerOfChat, "", chat, Guid.NewGuid());

            // Act
            chat.AddMessage(message);

            // Assert
            Assert.True(chat.MessageList.Count == 1);
        }

        [Test]
        public void AddMessage_NotOwnerAdds_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new Chanel(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.AddMessage(message));

            // Assert
            Assert.True(exception.Message == "This user can't send this message!");
        }

        [Test]
        public void AddMessage_NoUserInChatAdds_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new Chanel(chatId, ownerList, userList, messageList);

            var message = new Message(userNotInChat, "", chat, Guid.NewGuid());

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.AddMessage(message));

            // Assert
            Assert.True(exception.Message == "This user not found in this chat!");
        }
    }
}