using System.Collections.Generic;
using System.Linq;
using Messenger;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MessengerTests
{
    public class ChanelServiceTests
    {
        private UserService _userService;
        private ChanelService _chanelService;
        private UserRepository _userRepository;
        private ChanelRepository _chanelRepository;
        private MessageRepository _messageRepository;
        private List<IUser> _users;
        
        
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            _messageRepository = new MessageRepository();
            _chanelRepository = new ChanelRepository();
            _chanelService = new ChanelService(_userRepository, _messageRepository, _chanelRepository);
            
            _users = new List<IUser>()
            {
                _userRepository.CreateUser("1"),
                _userRepository.CreateUser("2"),
                _userRepository.CreateUser("3"),
            };
        }
        
        [Test]
        public void CreateChanel_SuccessSaved_IfValidUser()
        {
            var name = "name";
            var creator = _users[0];

            var chanel = _chanelService.CreateChanel(creator.Id, name);

            Assert.AreEqual(name, chanel.Name);
            var savedChanel = _chanelRepository.GetChanel(chanel.Id);
            Assert.True(savedChanel.Equals(chanel));
        }

        [Test]
        public void AddMember_SuccessAdded_IfValidUser()
        {
            var name = "name";
            var creator = _users[0];
            var chanel = _chanelService.CreateChanel(creator.Id, name);
            var member = _users[1];
            
            _chanelService.AddMember(member.Id, chanel.Id);

            var savedMembers = _chanelRepository.GetChanel(chanel.Id).GetMembers();

            Assert.AreEqual(1, savedMembers.Count);
            Assert.True(savedMembers.First().Equals(member));
        }

    }
}