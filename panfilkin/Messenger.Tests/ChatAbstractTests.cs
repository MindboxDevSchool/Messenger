using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChatAbstractTests
    {
        [Test]
        public void AddMessage_UserNotInThisChat_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userNotInChat, "", chat, Guid.NewGuid());

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.AddMessage(message));

            // Assert
            Assert.True(exception.Message == "This user not found in this chat!");
        }

        [Test]
        public void EditMessage_OwnerOfMessage_SuccessfulEdited()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            var newMessageTest = "new text";
            chat.AddMessage(message);


            // Act
            chat.EditMessage(userInChat, message, newMessageTest);

            // Assert
            Assert.AreEqual(newMessageTest, message.Text);
        }

        [Test]
        public void EditMessage_NotOwnerOfMessage_ThrowNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            var newMessageTest = "new text";
            chat.AddMessage(message);


            // Act
            var exception =
                Assert.Throws<NoPermissionException>(() => chat.EditMessage(userOwnerOfChat, message, newMessageTest));

            // Assert
            Assert.AreEqual("This user can't edit this message!", exception.Message);
        }

        [Test]
        public void EditMessage_NotUserInChat_ThrowNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            var newMessageTest = "new text";
            chat.AddMessage(message);


            // Act
            var exception =
                Assert.Throws<NotFoundException>(() => chat.EditMessage(userNotInChat, message, newMessageTest));

            // Assert
            Assert.AreEqual("This user not found in this chat!", exception.Message);
        }

        [Test]
        public void EditMessage_NoMessageInChat_ThrowNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            var newMessageTest = "new text";
            chat.AddMessage(message);
            chat.DeleteMessage(userInChat, message);


            // Act
            var exception =
                Assert.Throws<NotFoundException>(() => chat.EditMessage(userOwnerOfChat, message, newMessageTest));

            // Assert
            Assert.AreEqual("This message not found in this chat!", exception.Message);
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
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);


            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteMessage(userNotInChat, message));

            // Assert
            Assert.AreEqual("This user not found in this chat!", exception.Message);
        }

        [Test]
        public void DeleteMessage_UserNotOwnerOfChat_ThrowsNoPermissionException()
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
            chat.AddMessage(message);


            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.DeleteMessage(userInChat, message));

            // Assert
            Assert.AreEqual("This user can't delete this message!", exception.Message);
        }

        [Test]
        public void DeleteMessage_MessageNotFound_ThrowsNotFoundException()
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
            chat.AddMessage(message);
            chat.DeleteMessage(userOwnerOfChat, message);

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteMessage(userOwnerOfChat, message));

            // Assert
            Assert.AreEqual("This message not found in this chat!", exception.Message);
        }

        [Test]
        public void DeleteMessage_OwnerDeletesOtherMessage_SuccessfulDeleted()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            var message = new Message(userInChat, "", chat, Guid.NewGuid());
            chat.AddMessage(message);

            // Act
            chat.DeleteMessage(userOwnerOfChat, message);

            // Assert
            Assert.AreEqual(0, chat.MessageList.Count);
        }

        [Test]
        public void AddUser_UserNotInChat_SuccessfulAdded()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Act
            chat.AddUser(userNotInChat);

            // Assert
            Assert.True(chat.IsInUserList(userNotInChat));
        }

        [Test]
        public void AddUser_UserAlreadyInChat_NothingHappens()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Act
            chat.AddUser(userInChat);

            // Assert
            Assert.AreEqual(1, chat.UserList.Count);
        }

        [Test]
        public void DeleteUser_ActingUserNotInChat_ThrowsNotFoundException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");
            var userNotInChat = new User(Guid.NewGuid(), "someuser");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Act
            var exception = Assert.Throws<NotFoundException>(() => chat.DeleteUser(userNotInChat, userInChat));

            // Assert
            Assert.AreEqual("This user not found in this chat!", exception.Message);
        }

        [Test]
        public void DeleteUser_ActingUserNotOwner_ThrowsNoPermissionException()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Act
            var exception = Assert.Throws<NoPermissionException>(() => chat.DeleteUser(userInChat, userOwnerOfChat));

            // Assert
            Assert.AreEqual("This user can't delete this user!", exception.Message);
        }

        [Test]
        public void DeleteUser_OwnerDeletesUser_SuccessfulDeleted()
        {
            // Arrange
            var userOwnerOfChat = new User(Guid.NewGuid(), "silkslime");
            var userInChat = new User(Guid.NewGuid(), "userman");

            var chatId = Guid.NewGuid();
            var ownerList = new List<IUser>() {userOwnerOfChat};
            var userList = new List<IUser>() {userInChat};
            var messageList = new List<IMessage>();
            var chat = new GroupChat(chatId, ownerList, userList, messageList);

            // Act
            chat.DeleteUser(userOwnerOfChat, userInChat);

            // Assert
            Assert.AreEqual(0, userList.Count);
        }
    }
}