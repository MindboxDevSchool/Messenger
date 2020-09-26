using System.Collections.Generic;
using System.Linq;
using Messenger;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;

namespace MessengerTests
{
    public class ChatServiceTests
    {
        private UserService _userService;
        private UserRepository _userRepository;
        private MessageRepository _messageRepository;
        private ChatService _chatService;
        private List<IUser> _users;
        
        
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
            _messageRepository = new MessageRepository();
            _chatService = new ChatService(_userRepository, _messageRepository);
            
            _users = new List<IUser>()
            {
                _userRepository.CreateUser("1"),
                _userRepository.CreateUser("2"),
                _userRepository.CreateUser("3"),
            };
        }

        [Test]
        public void SendMessage_SuccessSaved_IfValidUsers()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";

            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);

            Assert.AreEqual(text, message.Text);
            var savedMessages = _messageRepository.GetMessages(sender, receiver);
            Assert.True(savedMessages.Any(m => m.Equals(message)));   
        }
        
        [Test]
        public void SendMessage_ThrowNotFoundException_IfInvalidUser()
        {
            var id = "invalid id";
            var validUserId = _users[0].Id;
            var text = "asd";
            
            Assert.Throws<NotFoundException>(()=>_chatService.SendMessage(id, validUserId, text));
            Assert.Throws<NotFoundException>(()=>_chatService.SendMessage(validUserId, id, text));
        }
        
        [Test]
        public void SendMessage_ThrowEmptyTextException_IfInvalidText()
        {
            var user1Id = _users[0].Id;
            var user2Id = _users[1].Id;
            var text = "";
            
            Assert.Throws<EmptyTextException>(()=>_chatService.SendMessage(user1Id, user2Id, text));
        }
        
        [Test]
        public void EditMessage_SuccessSaved_IfValidUsers()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            var newText = "new text";

            _chatService.EditMessage(message.Id, newText);
            
            Assert.AreEqual(
                newText, 
                _messageRepository.GetMessages(sender, receiver).First(m => m.Id == message.Id).Text);
        }
    }
}