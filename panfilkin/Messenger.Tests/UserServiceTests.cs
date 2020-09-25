using System;
using Messenger.Application;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class UserServiceTests
    {
        [Test]
        public void Constrictor_ValidConstructionData_SuccessfulConstructed()
        {
            // Arrange
            var userRepository = new UserRepository();
            
            // Act
            var userService = new UserService(userRepository);

            // Assert
            Assert.AreEqual(userRepository, userService.UserRepository);
        }
        
        [Test]
        public void RegisterUser_NotNullUser_SuccessfulRegistered()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            // Act
            var userId = userService.RegisterUser("silkslime");
            
            // Assert
            Assert.True(userService.UserRepository.Load(userId) != null);
        }
        
        [Test]
        public void RegisterUser_NullUser_ThrowsArgumentNullException()
        {
            // Arrange
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);

            // Act
            var exception = Assert.Throws<ArgumentNullException>( () => userService.RegisterUser(null) );
            
            // Assert
            Assert.True("" != exception.Message);
        }
    }
}