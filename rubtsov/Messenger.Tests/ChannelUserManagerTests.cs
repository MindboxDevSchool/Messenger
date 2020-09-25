using System;
using System.Security.Authentication;
using Messenger.Domain;
using Messenger.Domain.Channel;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChannelUserManagerTests
    {
        [Test]
        public void AddUserByNotAdmin_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            
            Assert.Throws<AuthenticationException>(() =>
            {
                channelUserManager.AddUsers(channelMember.Id, new []{notChannelMember});
            });
        }
        
        [Test]
        public void AddExistingMember_NumberOfChannelUsersDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 2;
            
            channelUserManager.AddUsers(channelAdmin.Id, new []{channelMember});
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void AddNewMember_NumberOfChannelUsersIncrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var newChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 3;
            
            channelUserManager.AddUsers(channelAdmin.Id, new []{newChannelMember});
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RemoveUserByNotAdmin_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channelMemberToRemove = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            
            Assert.Throws<AuthenticationException>(() =>
            {
                channelUserManager.RemoveUsers(channelMember.Id, new []{channelMemberToRemove});
            });
        }
        
        [Test]
        public void RemoveNonExistentChannelMember_NumberOfChannelUsersDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 2;
            
            channelUserManager.RemoveUsers(channelAdmin.Id, new []{notChannelMember});
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RemoveExistingChannelMember_NumberOfChannelUsersDecrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember, channelMember2});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 2;
            
            channelUserManager.RemoveUsers(channelAdmin.Id, new []{channelMember2});
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void LeaveChannelByAdmin_ThrowsArgumentException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember, channelMember2});
            var channelUserManager = new ChannelUserManager(channel);

            Assert.Throws<ArgumentException>(() =>
            {
                channelUserManager.LeaveChannel(channelAdmin.Id);
            });
        }
        
        [Test]
        public void LeaveChannelByNonExistentUser_NumberOfChannelUsersDontChange()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var notChannelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 2;
            
            channelUserManager.LeaveChannel(notChannelMember.Id);
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void LeaveChannelByChannelMember_NumberOfChannelUsersDecrease()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember, channelMember2});
            var channelUserManager = new ChannelUserManager(channel);
            const int expected = 2;
            
            channelUserManager.LeaveChannel(channelMember2.Id);
            var actual = channel.Users.Count;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ChangeAdminByNotAdmin_ThrowsAuthenticationException()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channelMember2 = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember, channelMember2});
            var channelUserManager = new ChannelUserManager(channel);

            Assert.Throws<AuthenticationException>(() =>
            {
                channelUserManager.ChangeAdmin(channelMember.Id, channelMember2.Id);
            });
        }
        
        [Test]
        public void ChangeAdminByAdmin_ChannelGetNewAdmin()
        {
            var channelAdmin = new User(Guid.NewGuid());
            var channelGuid = Guid.NewGuid();
            var channelMember = new User(Guid.NewGuid());
            var channel = new Channel(channelAdmin, channelGuid, new []{channelMember});
            var channelUserManager = new ChannelUserManager(channel);

            channelUserManager.ChangeAdmin(channelAdmin.Id, channelMember.Id);
            
            Assert.AreEqual(channelMember.Id, channel.Admin.Id);
        }
    }
}