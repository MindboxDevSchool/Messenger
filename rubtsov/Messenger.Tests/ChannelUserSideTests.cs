using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Channels;
using Messenger2.Application;
using Messenger2.Domain;
using Messenger2.Domain.Channel;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChannelUserSideTests
    {
        [Test]
        public void GetAllMessagesFromChannelWithoutMessages_ThrowsDataException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);

            Assert.Throws<DataException>(() =>
            {
                authenticatedUser.GetAllMessages();
            });
        }
        
        [Test]
        public void GetAllMessagesFromChannel_GetsAllChannelMessages()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelMember.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>() {message, message2});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            const int expected = 2;
            
            var actual = authenticatedUser.GetAllMessages().Count;

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GetUnreadMessagesByChannelMemberWithNoUnreadMessages_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelMember.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>{message});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            authenticatedUser.GetAllMessages();

            Assert.Throws<ArgumentException>(() =>
            {
                authenticatedUser.GetUnreadMessages();
            });
        }
        
        [Test]
        public void GetUnreadMessagesFromChannelWithNoMessages_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelMember.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
        
            Assert.Throws<ArgumentException>(() =>
            {
                authenticatedUser.GetUnreadMessages();
            });
        }
        
        [Test]
        public void GetUnreadMessagesByChannelMemberWithAllMessagesUnseen_GetsAllChannelMessages()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelMember.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>() {message, message2});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            const int expected = 2;
        
            var actual = authenticatedUser.GetUnreadMessages().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GetUnreadMessagesByChannelMember_GetsAllUnreadMessages()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelAdmin.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            channelMember.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>() {message});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            authenticatedUser.GetAllMessages();
            authenticatedAdmin.SendMessage(message2);
            const int expected = 1;
        
            var actual = authenticatedUser.GetUnreadMessages().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void LeaveChannelByAdmin_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);

            Assert.Throws<ArgumentException>(() =>
            {
                authenticatedUser.LeaveChannel();
            });
        }

        [Test]
        public void LeaveChannelByChannelMember_NumberOfChannelUsersDecrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember, channelMember2}, 
                new List<IMessage>());
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            const int expected = 2;
            
            authenticatedUser.LeaveChannel();
            var actual = authenticatedUser.GetUsers().Count;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMessage_GetsAllMessagesContainingSearchString()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var message = new Message(channelAdmin.Id, "This is the first message for search");
            var message2 = new Message(channelAdmin.Id, "This is Good bye message! this is");
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>() {message, message2});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            const int expected = 2;

            var actual = authenticatedUser.FindMessage("this is").Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void FindMessageWithUniqueString_NoMessagesFound()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var message = new Message(channelAdmin.Id, "This is the first message for search");
            var message2 = new Message(channelAdmin.Id, "This is Good bye message!");
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>() {message, message2});
            var authenticatedUser = channelService.AuthenticateAsUser(channelMember);
            const int expected = 0;

            var actual = authenticatedUser.FindMessage("abcdefgqwerty").Count;
            
            Assert.AreEqual(expected, actual);
        }
    }
}