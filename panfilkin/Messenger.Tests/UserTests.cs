using System;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class UserTests
    {
        [Test]
        public void Constructor_ValidData_SuccessfulConstructed()
        {
            // Arrange
            var userId = Guid.NewGuid();
            const string username = "silkslime";

            // Act
            var user = new User(userId, username);

            // Assert
            Assert.AreEqual(userId, user.Id);
            Assert.AreEqual(username, user.Username);
        }
    }
}