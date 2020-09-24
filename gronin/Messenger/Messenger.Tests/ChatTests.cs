using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class Tests
    {
        [Test]
        public void SendMessage_MemberOfChatSentMessage_MessageIsSent()
        {
            var user = new User(new UserData{Name = "1"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(user,messages,users);
            
            var messageId = group.SendMessage(user, "Hello!");
            var message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello!", message.Text);
        }
        
        [Test]
        public void SendMessage_UserNotFromChatSentMessage_MessageIsNotSent()
        {
            var admin = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(admin,messages,users);
            
            var messageId = group.SendMessage(user2, "Hello, Guys!");
            var message = group.GetMessage(messageId);
            
            Assert.IsNull(message);
        }
        
        [Test]
        public void DeleteMessage_MemberOfGroupDeletedOwnMessage_MessageIsDeleted()
        {
            var user = new User(new UserData{Name = "1"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(user,messages,users);
            
            var messageId = group.SendMessage(user, "Hello!");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(user, message);
            message = group.GetMessage(messageId);
            
            Assert.IsNull(message);
        }
        
        [Test]
        public void DeleteMessage_MemberOfGroupDeletedAnothersMessage_MessageIsNotDeleted()
        {
            var admin = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(admin,messages,users);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(admin, "Hello");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(user2, message);
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello", message.Text);
        }
        
        [Test]
        public void DeleteMessage_AdminOfGroupDeletedAnothersMessage_MessageIsDeleted()
        {
            var admin = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(admin,messages,users);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(user2, "Hello");
            var message = group.GetMessage(messageId);
            group.DeleteMessage(admin, message);
            message = group.GetMessage(messageId);
            
            Assert.IsNull(message);
        }
        
        [Test]
        public void EditMessage_MemberOfGroupEditedOwnMessage_MessageIsEdited()
        {
            var admin = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(admin,messages,users);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(admin, "Hello");
            var message = group.GetMessage(messageId);
            group.EditMessage(admin, message, "Goodbye");
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Goodbye", message.Text);
        }
        
        [Test]
        public void EditMessage_AdminOfGroupEditedAnothersMessage_MessageIsNotEdited()
        {
            var admin = new User(new UserData{Name = "1"});
            var user2 = new User(new UserData{Name = "2"});
            var users = new UserRepository();
            var messages = new MessageInGroupRepository();
            var group = new Chat(admin,messages,users);
            group.AddNewMember(user2);
            
            var messageId = group.SendMessage(user2, "Hello");
            var message = group.GetMessage(messageId);
            group.EditMessage(admin, message, "Hell");
            message = group.GetMessage(messageId);
            
            Assert.AreEqual("Hello", message.Text);
        }
    }
}