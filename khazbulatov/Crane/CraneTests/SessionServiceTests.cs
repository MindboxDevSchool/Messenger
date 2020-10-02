using System.Linq;
using Crane.Application;
using Crane.Domain;
using Crane.Infrastructure;
using NUnit.Framework;

namespace CraneTests
{
    [TestFixture]
    public class SessionServiceTests
    {
        [Test]
        public void NewMessageIdIsZero()
        {
            // Arrange
            string alicePassword = "trustno1";
            IUser alice = new User(0, "Alice", new SHA256PasswordHandler(alicePassword));

            IIdentityProvider idProvider = new SequentialIdentityProvider();
            IRepo<ISession> sessionRepo = new InMemoryRepo<ISession>();
            SessionService sessionService = new SessionService(idProvider, sessionRepo);
            
            int expectedSessionId = 0;

            // Act
            sessionService.CreateSession(alice, alicePassword);
            
            // Assert
            Assert.AreEqual(expectedSessionId, sessionRepo.Items.First().Id);
        }
    }
}
