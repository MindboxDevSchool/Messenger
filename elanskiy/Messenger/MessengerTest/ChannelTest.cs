using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;
using Messenger.Infrastructure;
using NUnit.Framework;

namespace PrivateChatTest
{
    public class ChannelTest
    {
        private Guid _userId1;
        private Guid _userId2;
        private IChannelManager _channelManager;

        [SetUp]
        public void Setup()
        {
            _userId1 = Guid.NewGuid();
            _userId2 = Guid.NewGuid();
            _channelManager = new ChannelManager(new ChannelRepository());
            for (var i = 0; i < 10; i++)
                _channelManager.CreateChannel(Guid.NewGuid(), $"testGroup{i}");
        }

        [Test]
        public void AfterCreatingChannel_ChannelShouldBeEmptyWithOneAdmin()
        {
            var channelId = _channelManager.CreateChannel(_userId1, "testGroup");
            var channel = _channelManager.GetChannel(_userId1, channelId);
            
            Assert.AreEqual(channelId, channel.Id);
            Assert.AreEqual(0, channel.Users.Count());
            Assert.True(channel.Admins.All(e => e == _userId1));
            Assert.AreEqual(channel.Name, "testGroup");
        }

        [Test]
        public void AfterCreatingChannel_CatchExceptionWhenUserNotAdminTriesPublishPost()
        {
            var channelId = _channelManager.CreateChannel(_userId1, "testGroup");
            var messageId = _channelManager.CreateMessage(_userId1, channelId, "test!");

            Assert.Catch<ApplicationException>
                (() => _channelManager.EditMessage(_userId2, channelId, messageId, "new next!"));
        }
        
        [Test]
        public void ChangeText_TextMustBeChanged()
        {
            var channelId = _channelManager.CreateChannel(_userId1, "testGroup");
            var messageId = _channelManager.CreateMessage(_userId1, channelId, "test!");
            _channelManager.EditMessage(_userId1, channelId, messageId, "new next!");

            Assert.AreEqual("new next!", _channelManager.GetMessage(_userId1, channelId,messageId).Text);
        }

        [Test]
        public void CheckIsMessageDeleted()
        {
            var groupId = _channelManager.CreateChannel(_userId1, "testGroup");
            var messageId = _channelManager.CreateMessage(_userId1, groupId, "test!");
            _channelManager.RemoveMessage(_userId1, groupId, messageId);

             Assert.Catch<KeyNotFoundException>
                  (() => _channelManager.GetMessage(_userId1, groupId, messageId));
        }
    }
}