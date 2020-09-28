using System;
using Messenger.Domain;
using NUnit.Framework;
namespace Messenger.Tests
{
    public class GroupChannelTests
    {
        [Test]
        public void SendMessage_AuthorOfSentMessage_MessageIsSent()
        {
            var author = new User(new UserData{Name = "1"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        
        [Test]
        public void SendMessage_MemberOfChannelSentMessage_MessageIsNotSent()
        {
            var author = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            
            Assert.Catch<ArgumentException>(()=>channel.SendMessage(user2, "Hello!"));
        }
        
        [Test]
        public void SendMessage_UserNotFromGroupSentMessage_MessageIsNotSent()
        {
            var author = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);

            Assert.Catch<ArgumentException>(()=>channel.SendMessage(user2, "Hello!"));
        }
        
        [Test]
        public void DeleteMessage_MemberOfGroupDeletedMessage_MessageIsNotDeleted()
        {
            var author = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            channel.DeleteMessage(user2, message);
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        

        [Test]
        public void DeleteMessage_AuthorOfGroupDeletedMessage_MessageIsDeleted()
        {
            var author = new User(new UserData{Name = "1"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            
            var messageId = channel.SendMessage(author, "Hello!");
            var message = channel.GetMessage(messageId);
            channel.DeleteMessage(author, message);
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
        
        [Test]
        public void EditMessage_MemberOfGroupEditedMessage_MessageIsNotEdited()
        {
            var author = new User(new UserData{Name = "1"});
            var user2= new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            channel.AddNewMember(user2);
            
            var messageId = channel.SendMessage(author, "Hello, Kolya!");
            var message = channel.GetMessage(messageId);
            channel.EditMessage(user2, message, "Goodbye, Kolya!");
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Hello, Kolya!", message.Text);
        }
        
        [Test]
        public void EditMessage_AuthorOfGroupEditedMessage_MessageIsEdited()
        {
            var author = new User(new UserData{Name = "1"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var channel = new GroupChannel(author,messages,users);
            
            var messageId = channel.SendMessage(author, "Hello");
            var message = channel.GetMessage(messageId);
            channel.EditMessage(author, message, "Goodbye");
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye", message.Text);
        }
    }
}