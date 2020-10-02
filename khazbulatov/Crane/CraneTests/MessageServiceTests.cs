using System.Linq;
using Crane.Application;
using Crane.Domain;
using Crane.Infrastructure;
using NUnit.Framework;

namespace CraneTests
{
    [TestFixture]
    public class MessageServiceTests
    {
        [Test]
        public void PrivateChatMessageSent()
        {
            // Arrange
            IUser alice = new User(0, "Alice", new SHA256PasswordHandler("trustno1"));
            IUser bob = new User(1, "Bob", new SHA256PasswordHandler("trustno1"));
            
            IIdentityProvider idProvider = new SequentialIdentityProvider();
            IRepo<IMessage> messageRepo = new InMemoryRepo<IMessage>();
            IChat chat = new PrivateChat(0, idProvider, messageRepo, alice, bob);
            MessageService messageService = new MessageService();
            
            int expectedMessageId = 0;

            // Act
            messageService.TrySendMessage(alice, chat, "Hi, Bob! What are you up to?");
            
            // Assert
            Assert.AreEqual(expectedMessageId, messageRepo.Items.First().Id);
        }
    }
}
