using System;
using System.Collections.Generic;
using Application.Services.MessageServices;
using AutoFixture;
using Domain.Chats;
using Domain.Message;
using Domain.User;
using MessengerTests.TestRepositories;
using NUnit.Framework;

namespace MessengerTests
{
    public class MessageServiceTests
    {
        private Fixture _fixture;
        private MessageService _messageService;

        [SetUp]
        public void Setup()
        {
            _messageService = new MessageService(
                new TestMessageRepository(new Dictionary<Guid, IMessage>()), 
                new TestChatRepository(new Dictionary<Guid, IChat>()),
                new TestUserRepository(new Dictionary<Guid, IUser>()), 
                new TestUserContext(new Guid())
            );
        }

        [Test]
        public void Test1()
        {
            var userId = new Guid();
            var user = User.Create(userId, new UserName("Stepa"), new PhoneNumber("123"));

            var chatId = new Guid();
            var group = Group.Create(chatId);
        }
    }
}