using System;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class PrivateChatTests
    {
        [Test]
        public void SendMessage_MemberOfPrivateChatSentMessage_MessageIsSent()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            var messageId = privateChat.SendMessage(user1, "Hello");
            var message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello", message.Text);
        }
        
        [Test]
        public void SendMessage_UserNotFromPrivateChatSentMessage_MessageIsNotSent()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var user3= new User(new UserData{Name = "3"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            Assert.Catch<ArgumentException>(()=>privateChat.SendMessage(user3, "Hello, Guys!"));
        }
        
        [Test]
        public void DeleteMessage_MemberOfPrivateChatDeletedOwnMessage_MessageIsDeleted()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            var messageId = privateChat.SendMessage(user1, "Hello");
            var message = privateChat.GetMessage(messageId);
            privateChat.DeleteMessage(user1, message);
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void DeleteMessage_MemberOfPrivateChatDeletedAnothersMessage_MessageIsNotDeleted()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData {Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            var messageId = privateChat.SendMessage(user1, "Hello");
            var message = privateChat.GetMessage(messageId);
            privateChat.DeleteMessage(user2, message);
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello", message.Text);
        }
        
        [Test]
        public void EditMessage_MemberOfPrivateChatEditedOwnMessage_MessageIsEdited()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData {Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            var messageId = privateChat.SendMessage(user1, "Hello");
            var message = privateChat.GetMessage(messageId);
            privateChat.EditMessage(user1, message, "Goodbye");
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye", message.Text);
        }
        
        [Test]
        public void EditMessage_MemberOfPrivateChatEditedAnothersMessage_MessageIsNotEdited()
        {
            var user1 = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData {Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var privateChat = new PrivateChat(user1,user2,messages,users);
            
            var messageId = privateChat.SendMessage(user1, "Hello");
            var message = privateChat.GetMessage(messageId);
            privateChat.EditMessage(user2, message, "Goodbye");
            message = privateChat.GetMessage(messageId);
            
            Assert.AreEqual("Hello", message.Text);
        }
    }
}