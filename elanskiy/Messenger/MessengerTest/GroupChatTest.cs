using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;
using Messenger.Infrastructure;
using NUnit.Framework;

namespace PrivateChatTest
{
    public class GroupChatTest
    {
        private Guid _userId1;
        private Guid _userId2;
        private IGroupManager _groupChatManager;

        [SetUp]
        public void Setup()
        {
            _userId1 = Guid.NewGuid();
            _userId2 = Guid.NewGuid();
            _groupChatManager = new GroupManager(new GroupRepository());
            for (var i = 0; i < 10; i++)
                _groupChatManager.CreateGroupChat(Guid.NewGuid(), $"testGroup{i}");
        }

        [Test]
        public void AfterCreatingGroup_GroupShouldBeEmptyWithOneAdmin()
        {
            var groupId = _groupChatManager.CreateGroupChat(_userId1, "testGroup");
            var group = _groupChatManager.GetGroup(_userId1, groupId);
            
            Assert.AreEqual(groupId, group.Id);
            Assert.AreEqual(0, group.Users.Count());
            Assert.True(group.Admins.All(e => e == _userId1));
            Assert.AreEqual(group.Name, "testGroup");
        }

        [Test]
        public void AfterCreatingGroup_CatchExceptionWhenUserNotInGroupTriesCreateMessage()
        {
            var groupId = _groupChatManager.CreateGroupChat(_userId1, "testGroup");
            var messageId = _groupChatManager.CreateMessage(_userId1, groupId, "test!");

            Assert.Catch<ApplicationException>
                (() => _groupChatManager.EditMessage(_userId2, messageId, "new next!"));
        }
        
        [Test]
        public void ChangeText_TextMustBeChanged()
        {
            var groupId = _groupChatManager.CreateGroupChat(_userId1, "testGroup");
            var messageId = _groupChatManager.CreateMessage(_userId1, groupId, "test!");
            _groupChatManager.EditMessage(_userId1, messageId, "new next!");

            Assert.AreEqual("new next!", _groupChatManager.GetMessage(_userId1, groupId,messageId).Text);
        }

        [Test]
        public void CheckIsMessageDeleted()
        {
            var groupId = _groupChatManager.CreateGroupChat(_userId1, "testGroup");
            var messageId = _groupChatManager.CreateMessage(_userId1, groupId, "test!");
            _groupChatManager.RemoveMessage(_userId1, groupId, messageId);

             Assert.Catch<KeyNotFoundException>
                  (() => _groupChatManager.GetMessage(_userId1, groupId, messageId));
        }
    }
}