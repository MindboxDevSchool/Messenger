using System.Collections.Generic;
using System.Linq;
using Messenger;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MessengerTests
{
    public class ChannelServiceTests
    {
        private UserService _userService;
        private ChannelService _channelService;
        private UserRepository _userRepository;
        private ChannelRepository _channelRepository;
        private MessageRepository _messageRepository;
        private List<IUser> _users;


        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            _messageRepository = new MessageRepository();
            _channelRepository = new ChannelRepository();
            _channelService = new ChannelService(_userRepository, _messageRepository, _channelRepository);

            _users = new List<IUser>()
            {
                _userRepository.CreateUser("1"),
                _userRepository.CreateUser("2"),
                _userRepository.CreateUser("3"),
            };
        }

        [Test]
        public void CreateChannel_SuccessSaved_IfValidUser()
        {
            var name = "name";
            var creator = _users[0];

            var channel = _channelService.CreateChannel(creator.Id, name);

            Assert.AreEqual(name, channel.Name);
            var savedChannel = _channelRepository.GetChannel(channel.Id);
            Assert.True(savedChannel.Equals(channel));
        }

        [Test]
        public void AddMember_SuccessAdded_IfValidUser()
        {
            var name = "name";
            var creator = _users[0];
            var channel = _channelService.CreateChannel(creator.Id, name);
            var member = _users[1];

            _channelService.AddMember(member.Id, channel.Id);

            var savedMembers = _channelRepository.GetChannel(channel.Id).GetMembers();

            Assert.AreEqual(1, savedMembers.Count);
            Assert.True(savedMembers.First().Equals(member));
        }
    }
}