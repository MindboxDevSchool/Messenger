using System.Collections.Generic;
using System.Linq;
using Messenger;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MessengerTests
{
    public class GroupServiceTests
    {
        private UserService _userService;
        private GroupService _groupService;
        private UserRepository _userRepository;
        private GroupRepository _groupRepository;
        private MessageRepository _messageRepository;
        private List<IUser> _users;


        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            _messageRepository = new MessageRepository();
            _groupRepository = new GroupRepository();
            _groupService = new GroupService(_userRepository, _messageRepository, _groupRepository);

            _users = new List<IUser>()
            {
                _userRepository.CreateUser("1"),
                _userRepository.CreateUser("2"),
                _userRepository.CreateUser("3"),
            };
        }
        
        [Test]
        public void EditMessage_SuccessEdited_IfEditorIsAdmin()
        {
            var group = _groupService.CreateGroup(_users[0].Id, "name");
            _groupService.AddMember(_users[1].Id, group.Id);
            var message = _groupService.SendMessage(_users[1].Id, group.Id, "message");
            var newText = "new message";
            
            _groupService.EditMessage(message.Id, _users[0].Id, newText);
            
            Assert.AreEqual(
                newText,
                _messageRepository.GetMessages(group).First(m => m.Id == message.Id).Text);
        }

        [Test]
        public void EditMessage_ThrowAccessException_IfEditorHaveNoAccess()
        {
            var group = _groupService.CreateGroup(_users[0].Id, "name");
            _groupService.AddMember(_users[1].Id, group.Id);
            _groupService.AddMember(_users[2].Id, group.Id);
            var message = _groupService.SendMessage(_users[1].Id, group.Id, "message");
            var newText = "new message";
            
            Assert.Throws<InvalidAccessException>(() => _groupService.EditMessage(message.Id, _users[2].Id, newText));
        }
    }
}