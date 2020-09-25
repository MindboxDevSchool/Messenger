using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class MessageTests
    {
        [Test]
        public void Constructor_ValidConstructorData_SuccessfulConstructed()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), "silkslime");
            var messageText = "some text";
            var messageId = Guid.NewGuid();

            var chat = new Chanel(Guid.NewGuid(), new List<IUser>() {user}, new List<IUser>(), new List<IMessage>());

            // Act
            var message = new Message(user, messageText, chat, messageId);

            // Assert
            Assert.AreEqual(user, message.Sender);
            Assert.AreEqual(messageText, message.Text);
            Assert.AreEqual(chat, message.Chat);
            Assert.AreEqual(messageId, message.Id);
            Assert.NotNull(message.DateTime);
        }
    }
}