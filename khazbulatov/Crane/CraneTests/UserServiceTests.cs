using System.Linq;
using Crane.Application;
using Crane.Domain;
using Crane.Infrastructure;
using NUnit.Framework;

namespace CraneTests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void NewUserIdIsZero()
        {
            // Arrange
            IIdentityProvider idProvider = new SequentialIdentityProvider();
            IRepo<IUser> userRepo = new InMemoryRepo<IUser>();
            UserService userService = new UserService(idProvider, userRepo);
            
            int expectedSessionId = 0;

            // Act
            userService.CreateUser("Alice", "trustno1");
            
            // Assert
            Assert.AreEqual(expectedSessionId, userRepo.Items.First().Id);
        }
    }
}
