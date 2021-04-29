using System.Linq;
using Crane.Application;
using Crane.Domain;
using Crane.Infrastructure;
using NUnit.Framework;

namespace CraneTests
{
    [TestFixture]
    public class ChatServiceTests
    {
        [Test]
        public void NewPrivateChatIdIsZero()
        {
            // Arrange
            IUser alice = new User(0, "Alice", new SHA256PasswordHandler("trustno1"));
            IUser bob = new User(1, "Bob", new SHA256PasswordHandler("trustno1"));
            
            IIdentityProvider idProvider = new SequentialIdentityProvider();
            IRepo<IChat> chatRepo = new InMemoryRepo<IChat>();
            ChatService chatService = new ChatService(idProvider, chatRepo);
            
            int expectedChatId = 0;

            // Act
            chatService.CreatePrivateChat(alice, bob);
            
            // Assert
            Assert.AreEqual(expectedChatId, chatRepo.Items.First().Id);
        }
    }
}
