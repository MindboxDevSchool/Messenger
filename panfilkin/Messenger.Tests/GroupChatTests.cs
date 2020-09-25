using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class GroupChatTests
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
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Assert
            Assert.AreEqual(chatId, chat.Id);
            Assert.True(chat.IsInOwnerList(userOwner));
            Assert.True(chat.IsInUserList(user));
        }
    }
}