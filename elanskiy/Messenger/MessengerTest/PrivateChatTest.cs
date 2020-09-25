using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Application;
using Messenger.Domain;
using Messenger.Infrastructure;
using NUnit.Framework;

namespace PrivateChatTest
{
    public class Tests
    {
        private Guid _userId1;
        private Guid _userId2;
        private IPrivateChatManager _privateChatManager;

        [SetUp]
        public void Setup()
        {
            _userId1 = Guid.NewGuid();
            _userId2 = Guid.NewGuid();
            _privateChatManager = new PrivateChatManager(new PrivateChatRepository());
            for (var i = 0; i < 10; i++)
                _privateChatManager.CreatePrivateChat(Guid.NewGuid(), Guid.NewGuid());
        }

        [Test]
        public void AfterCreatingNewChat_ChatShouldBe()
        {
            var chatId = _privateChatManager.CreatePrivateChat(_userId1, _userId2);
            var chat = _privateChatManager.GetChat(_userId1, chatId);
            
            Assert.AreEqual(chatId, chat.Id);
            Assert.AreEqual(2, chat.Users.Length);
            Assert.True(chat.Users.Contains(_userId1));
            Assert.True(chat.Users.Contains(_userId2));
        }

        [Test]
        public void AfterCreatingMessage_CatchExceptionWhenTryingModifyMessageIfYouAreNotOwner()
        {
            var chatId = _privateChatManager.CreatePrivateChat(_userId1, _userId2);
            var messageId = _privateChatManager.CreateMessage(_userId1, _userId2, "test!");

            Assert.Catch<ApplicationException>
                (() => _privateChatManager.EditMessage(_userId2, chatId, messageId, "new next!"));
        }
        
        [Test]
        public void AfterCreatingMessageChangeText_CheckIsTextChanged()
        {
            var chatId = _privateChatManager.CreatePrivateChat(_userId1, _userId2);
            var messageId = _privateChatManager.CreateMessage(_userId1, _userId2, "test!");
            _privateChatManager.EditMessage(_userId1, chatId, messageId, "new next!");

            Assert.AreEqual("new next!", _privateChatManager.GetMessage(_userId1, chatId,messageId).Text);
        }

        [Test]
        public void CheckIsMessageDeleted()
        {
            var chatId = _privateChatManager.CreatePrivateChat(_userId1, _userId2);
            var messageId = _privateChatManager.CreateMessage(_userId1, _userId2, "test!");
            _privateChatManager.RemoveMessage(_userId1, chatId, messageId);

             Assert.Catch<KeyNotFoundException>
                  (() => _privateChatManager.GetMessage(_userId1, chatId, messageId));
        }

    }
}