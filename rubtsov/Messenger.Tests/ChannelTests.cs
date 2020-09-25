using System;
using System.Security.Authentication;
using Messenger.Domain;
using Messenger.Domain.Channel;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChannelTests
    {
        
        [Test]
        public void SendNewMessage_NumberOfAllMessagesIncreased()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            const int expected = 1;
            
            channel.SendMessage(channelAdmin.Id, message);
            var allMessages = channel.GetAllMessages(channelAdmin.Id);
            
            Assert.AreEqual(expected, allMessages.Count);
        }
        
        [Test]
        public void SendNewMessage_ChannelMemberGetsNotification()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");

            channel.SendMessage(channelAdmin.Id, message);

            Assert.True(channelMember.LastSeenMessageInParticipatingCommunities[channelGuid].HaveNewMessages);
        }
        
        [Test]
        public void SendNewMessageByNotAdmin_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelMember.Id, "Hello all!");

            Assert.Throws<AuthenticationException>(() =>
            {
                channel.SendMessage(channelMember.Id, message);
            });
        }
        
        [Test]
        public void DeleteMessage_NumberOfAllMessagesDecreased()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            var messageForDeletion = new Message(channelAdmin.Id, "Good bye!");
            channel.SendMessage(channelAdmin.Id, message);
            channel.SendMessage(channelAdmin.Id, messageForDeletion);
            const int expected = 1;
            
            channel.DeleteMessage(channelAdmin.Id, messageForDeletion);
            
            Assert.AreEqual(expected, channel.GetAllMessages(channelAdmin.Id).Count);
        }
        
        [Test]
        public void DeleteNonExistentMessage_NumberOfAllMessagesDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            var outsideMessage = new Message(channelAdmin.Id, "Good bye!");
            channel.SendMessage(channelAdmin.Id, message);
            const int expected = 1;
            
            channel.DeleteMessage(channelAdmin.Id, outsideMessage);
            
            Assert.AreEqual(expected, channel.GetAllMessages(channelAdmin.Id).Count);
        }
        
        [Test]
        public void GetAllMessagesByNotChannelMember_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});

            Assert.Throws<AuthenticationException>(() =>
            {
                channel.GetAllMessages(notChannelMember.Id);
            });
        }
        
        [Test]
        public void GetAllMessagesFromChannelWithoutMessages_ThrowsDataException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});

            Assert.Throws<NullReferenceException>(() =>
            {
                channel.GetAllMessages(channelMember.Id);
            });
        }
        
        [Test]
        public void GetUnreadMessagesByNotChannelMember_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});

            Assert.Throws<AuthenticationException>(() =>
            {
                channel.GetUnreadMessages(notChannelMember.Id);
            });
        }
        
        [Test]
        public void GetUnreadMessagesByChannelMemberWithNoUnreadMessages_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            channel.SendMessage(channelAdmin.Id, message);
            channel.GetAllMessages(channelMember.Id);
            
            Assert.Throws<ArgumentException>(() =>
            {
                channel.GetUnreadMessages(channelMember.Id);
            });
        }
        
        [Test]
        public void GetUnreadMessagesFromChannelWithNoMessages_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});

            Assert.Throws<ArgumentException>(() =>
            {
                channel.GetUnreadMessages(channelMember.Id);
            });
        }
        
        [Test]
        public void GetUnreadMessagesByChannelMemberWithAllMessagesUnseen_GetsAllChannelMessages()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            channel.SendMessage(channelAdmin.Id, message);
            channel.SendMessage(channelAdmin.Id, message2);
            const int expected = 2;

            var actual = channel.GetUnreadMessages(channelMember.Id).Count;
            
            Assert.AreEqual(expected, actual);
        }
  
        [Test]
        public void GetUnreadMessagesByChannelMember_GetsAllUnreadMessages()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            channel.SendMessage(channelAdmin.Id, message);
            channel.GetAllMessages(channelMember.Id);
            channel.SendMessage(channelAdmin.Id, message2);
            const int expected = 1;

            var actual = channel.GetUnreadMessages(channelMember.Id).Count;
            
            Assert.AreEqual(expected, actual);
        }
    }
}