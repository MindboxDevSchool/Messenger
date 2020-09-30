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
        private IUser _currentUser;
        
        [SetUp]
        public void Setup()
        {
            _userRepository = new TestUserRepository(new Dictionary<Guid, IUser>());
            _chatRepository = new TestChatRepository(new Dictionary<Guid, IChat>());
            
            // create current user
            var currentUserId = Guid.NewGuid();
            _currentUser = User.Create(currentUserId, new UserName("S1"), new PhoneNumber("1"));
            _userRepository.Add(_currentUser);
            
            // we are logged in as current user
            _userContext = new TestUserContext(currentUserId);
            _chatService = new ChatService(_userContext, _chatRepository, _userRepository);
        }

        [Test]
        public void Private_chat_creation_test()
        {
            // create other user
            var otherUserId = Guid.NewGuid();
            var otherUser = User.Create(otherUserId, new UserName("S2"), new PhoneNumber("2"));
            _userRepository.Add(otherUser);
            var expectedChatMembers = new List<IUser> {_currentUser, otherUser};

            var createdChatId = _chatService.CreatePrivateChat(otherUserId);
            var createdChat = _chatRepository.Find(createdChatId);

            Assert.That(expectedChatMembers, Is.EquivalentTo(createdChat.Members.ToList()));
        }
        
        [Test]
        public void Group_creation_test()
        {
            var groupName = new ChatName("Group name");
            var groupDescription = new ChatDescription("Group description");
            var expectedChatMembers = new List<IUser> {_currentUser};

            var createdGroupId = _chatService.CreateGroup(groupName, groupDescription);
            var createdGroup = (IGroup)_chatRepository.Find(createdGroupId);

            Assert.AreEqual(_currentUser, createdGroup.Owner);
            Assert.True(createdGroup.Admins.Count == 0);
            Assert.AreEqual(groupName, createdGroup.Name);
            Assert.AreEqual(groupDescription, createdGroup.Description);
            CollectionAssert.AreEquivalent(expectedChatMembers, createdGroup.Members.ToList());
        }
        
        [Test]
        public void Channel_creation_test()
        {
            var channelName = new ChatName("Group name");
            var channelDescription = new ChatDescription("Group description");
            var expectedChatMembers = new List<IUser> {_currentUser};

            var createdChannelId = _chatService.CreateChannel(channelName, channelDescription);
            var createdChannel = (IChannel)_chatRepository.Find(createdChannelId);

            Assert.AreEqual(_currentUser, createdChannel.Owner);
            Assert.AreEqual(channelName, createdChannel.Name);
            Assert.AreEqual(channelDescription, createdChannel.Description);
            CollectionAssert.AreEquivalent(expectedChatMembers, createdChannel.Members.ToList());
        }
    }
}