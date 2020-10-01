using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Messenger2.Application;
using Messenger2.Domain;
using Messenger2.Domain.Channel;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChannelAdminSideTests
    {
        [Test]
        public void SendNewMessage_NumberOfAllMessagesIncreased()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var channelId = Guid.NewGuid();
            channelAdmin.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>(), 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            const int expected = 1;
            
            authenticatedAdmin.SendMessage(message);
            var actual = authenticatedUser.GetAllMessages().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void SendNewMessage_ChannelMemberGetsNotification()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelAdmin.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>(), 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            authenticatedAdmin.AddUsers(new []{channelMember});
            
            authenticatedAdmin.SendMessage(message);

            Assert.True(channelMember.LastSeenMessageInParticipatingCommunities[channelId].HaveNewMessages);
        }
        
        [Test]
        public void DeleteMessage_ContentOfTheDeletedMessageChanged()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelAdmin.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var messageForDeletion = new Message(channelAdmin.Id, "Good bye!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>(), 
                new List<IMessage> {message, messageForDeletion});
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            var expected = messageForDeletion.MessageContent;

            authenticatedAdmin.DeleteMessage(messageForDeletion);
            var actual = authenticatedUser.GetAllMessages().Last().MessageContent;
            
            Assert.AreNotEqual(expected, actual);
        }
        
        [Test]
        public void DeleteNonExistentMessage_ContentOfExistentMessagesDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            channelAdmin.LastSeenMessageInParticipatingCommunities.Add(channelId, new LastSeenMessage());
            var message = new Message(channelAdmin.Id, "Hello all!");
            var message2 = new Message(channelAdmin.Id, "Good bye!");
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>(), 
                new List<IMessage> {message, message2});
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            var notChannelMessage = new Message(channelAdmin.Id, "Good bye!");
            
            authenticatedAdmin.DeleteMessage(notChannelMessage);
            var channelMessages = authenticatedUser.GetAllMessages();
            
            Assert.AreEqual(message.MessageContent, channelMessages.First().MessageContent);
            Assert.AreEqual(message2.MessageContent, channelMessages.Last().MessageContent);
        }
        
        [Test]
        public void AddExistingMember_NumberOfChannelUsersDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelId = Guid.NewGuid();
            var channelService = new ChannelService(channelAdmin, 
                channelId, 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            const int expected = 2;
            
            authenticatedAdmin.AddUsers(new []{channelMember});
            var actual = authenticatedUser.GetUsers().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AddNewMember_NumberOfChannelUsersIncrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var newChannelMember = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            const int expected = 3;
            
            authenticatedAdmin.AddUsers(new []{newChannelMember});
            var actual = authenticatedUser.GetUsers().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RemoveNonExistentChannelMember_NumberOfChannelUsersDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            const int expected = 2;
            
            authenticatedAdmin.RemoveUsers(new []{notChannelMember});
            var actual = authenticatedUser.GetUsers().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RemoveExistingChannelMember_NumberOfChannelUsersDecrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember, channelMember2}, 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            const int expected = 2;
            
            authenticatedAdmin.RemoveUsers(new []{channelMember2});
            var actual = authenticatedUser.GetUsers().Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAdmin_ChannelGetNewAdmin()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelMember = new User(Guid.NewGuid());
            var channelService = new ChannelService(channelAdmin, 
                Guid.NewGuid(), 
                new HashSet<IUser>() {channelAdmin, channelMember}, 
                new List<IMessage>());
            var authenticatedAdmin = channelService.AuthenticateAsAdmin(channelAdmin);
            var authenticatedUser = channelService.AuthenticateAsUser(channelAdmin);
            
            authenticatedAdmin.ChangeAdmin(channelMember);
            
            Assert.AreEqual(channelMember.Id, authenticatedUser.GetAdmin().Id);
        }
    }
}