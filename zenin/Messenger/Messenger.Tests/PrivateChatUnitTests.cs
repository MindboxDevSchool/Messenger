using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class PrivateChatUnitTests
    {
        [Test]
        public void MemberOfPrivateChatSentMessage_MessageIsSent()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user1, "Hello, Kolya!");
            var message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
        
        [Test]
        public void UserNotFromPrivateChatSentMessage_MessageIsNotSent()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var user3 = new User("Someone");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user3, "Hello, Guys!");
            var message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfPrivateChatDeletedOwnMessage_MessageIsDeleted()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user1, "Hello, Kolya!");
            var message = privateChat.GetMessage(messageId);
            privateChat.DeleteMessage(user1, message);
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfPrivateChatDeletedAnothersMessage_MessageIsNotDeleted()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user1, "Hello, Kolya!");
            var message = privateChat.GetMessage(messageId);
            privateChat.DeleteMessage(user2, message);
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
        
        [Test]
        public void MemberOfPrivateChatEditedOwnMessage_MessageIsEdited()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user1, "Hello, Kolya!");
            var message = privateChat.GetMessage(messageId);
            privateChat.EditMessage(user1, message, "Goodbye, Kolya!");
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye, Kolya!", message.Text);
        }
        
        [Test]
        public void MemberOfPrivateChatEditedAnothersMessage_MessageIsNotEdited()
        {
            var user1 = new User("Petya");
            var user2 = new User("Kolya");
            var privateChat = new  PrivateChat(user1, user2);
            
            var messageId = privateChat.SendMessage(user1, "Hello, Kolya!");
            var message = privateChat.GetMessage(messageId);
            privateChat.EditMessage(user2, message, "Goodbye, Kolya!");
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
    }
}