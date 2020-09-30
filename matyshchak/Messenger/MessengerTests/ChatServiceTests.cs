using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Services.ChatServices;
using Application.Services.MessageServices;
using Application.Services.UserServices;
using Domain.Chats;
using Domain.Repository;
using Domain.User;
using FluentAssertions;
using MessengerTests.TestRepositories;
using NUnit.Framework;

namespace MessengerTests
{
    public class ChatServiceTests
    {
        private IChatService _chatService;
        private IUserService _userService;
        private IContext _userContext;
        private IRepository<IUser> _userRepository;
        private IRepository<IChat> _chatRepository;

        
        
        [SetUp]
        public void Setup()
        {
            _userRepository = new TestUserRepository(new Dictionary<Guid, IUser>());
            _chatRepository = new TestChatRepository(new Dictionary<Guid, IChat>());
            
        }

        [Test]
        public void Can_create_private_chat_between_two_users()
        {
            // create current user
            var currentUserId = Guid.NewGuid();
            var currentUser = User.Create(currentUserId, new UserName("S1"), new PhoneNumber("1"));
            _userRepository.Add(currentUser);
            
            // create other user
            var otherUserId = Guid.NewGuid();
            var otherUser = User.Create(otherUserId, new UserName("S2"), new PhoneNumber("2"));
            _userRepository.Add(otherUser);
            
            var expectedChatMembers = new List<IUser> {currentUser, otherUser};

            // we are logged in as current user
            _userContext = new TestUserContext(currentUserId);
            
            _chatService = new ChatService(_userContext, _chatRepository, _userRepository);
            var createdChatId = _chatService.CreatePrivateChat(otherUserId);
            var createdChat = _chatRepository.Find(createdChatId);

            Assert.That(expectedChatMembers, Is.EquivalentTo(createdChat.Members.ToList()));
        }
    }
}