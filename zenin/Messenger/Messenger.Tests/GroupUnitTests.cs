using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChannelUnitTests
    {
        [Test]
        public void AuthorOfSentMessage_MessageIsSent()
        {
            var author = new User("Petya");
            var channel = new  Channel(author);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        
        [Test]
        public void MemberOfChannelSentMessage_MessageIsNotSent()
        {
            var author = new User("Petya");
            var user2 = new User("Kolya");
            var channel = new  Channel(author);
            channel.AddNewMember(user2);
            
            var messageId = channel.SendMessage(user2, "Hello!");
            var message = channel.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void UserNotFromGroupSentMessage_MessageIsNotSent()
        {
            var author = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Channel(author);
            
            var messageId = group.SendMessage(user2, "Hello, Guys!");
            var message = group.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfGroupDeletedMessage_MessageIsNotDeleted()
        {
            var author = new User("Petya");
            var user2 = new User("Kolya");
            var channel = new  Channel(author);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            channel.DeleteMessage(user2, message);
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        

        [Test]
        public void AuthorOfGroupDeletedMessage_MessageIsDeleted()
        {
            var author = new User("Petya");
            var channel = new  Channel(author);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            channel.DeleteMessage(author, message);
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfGroupEditedMessage_MessageIsNotEdited()
        {
            var author = new User("Petya");
            var user2 = new User("Kolya");
            var channel = new  Channel(author);
            channel.AddNewMember(user2);
            
            var messageId = channel.SendMessage(author, "Hello, Kolya!");
            var message = channel.GetMessage(messageId);
            channel.EditMessage(user2, message, "Goodbye, Kolya!");
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
        
        [Test]
        public void AuthorOfGroupEditedMessage_MessageIsEdited()
        {
            var author = new User("Petya");
            var channel = new  Channel(author);
            
            var messageId = channel.SendMessage(author, "Hello, Kolya!");
            var message = channel.GetMessage(messageId);
            channel.EditMessage(author, message, "Goodbye, Kolya!");
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye, Kolya!", message.Text);
        }
    }
}