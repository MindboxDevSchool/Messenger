using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class GroupUnitTests
    {
        [Test]
        public void MemberOfGroupSentMessage_MessageIsSent()
        {
            var user = new User("Petya");
            var group = new  Group(user);
            
            var messageId = group.SendMessage(user, "Hello!");
            var message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        
        [Test]
        public void UserNotFromGroupSentMessage_MessageIsNotSent()
        {
            var superUser = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Group(superUser);
            
            var messageId = group.SendMessage(user2, "Hello, Guys!");
            var message = group.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfGroupDeletedOwnMessage_MessageIsDeleted()
        {
            var user = new User("Petya");
            var group = new  Group(user);
            
            var messageId = group.SendMessage(user, "Hello!");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(user, message);
            message = group.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfGroupDeletedAnothersMessage_MessageIsNotDeleted()
        {
            var superUser = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Group(superUser);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(superUser, "Hello, Kolya!");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(user2, message);
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
        
        [Test]
        public void SuperUserOfGroupDeletedAnothersMessage_MessageIsDeleted()
        {
            var superUser = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Group(superUser);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(user2, "Hello, Admin!");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(superUser, message);
            message = group.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void MemberOfGroupEditedOwnMessage_MessageIsEdited()
        {
            var superUser = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Group(superUser);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(superUser, "Hello, Kolya!");
            var message = group.GetMessage(messageId);
            group.EditMessage(superUser, message, "Goodbye, Kolya!");
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye, Kolya!", message.Text);
        }
        
        [Test]
        public void SuperuserOfGroupEditedAnothersMessage_MessageIsNotEdited()
        {
            var superUser = new User("Petya");
            var user2 = new User("Kolya");
            var group = new  Group(superUser);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(user2, "Hello, Admin!");
            var message = group.GetMessage(messageId);
            group.EditMessage(superUser, message, "Hello, God!");
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Admin!", message.Text);
        }
    }
}