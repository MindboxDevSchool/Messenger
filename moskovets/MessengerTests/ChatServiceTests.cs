using System.Collections.Generic;
using System.Linq;
using Messenger;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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

            _chatService.EditMessage(message.Id, sender.Id, newText);
            
            Assert.AreEqual(
                newText, 
                _messageRepository.GetMessages(sender, receiver).First(m => m.Id == message.Id).Text);
        }
        
        [Test]
        public void EditMessage_ThrowEmptyTextException_IfInvalidText()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            var newText = "";
            
            Assert.Throws<EmptyTextException>(()=>_chatService.EditMessage(message.Id, sender.Id, newText));
        }
        
        [Test]
        public void EditMessage_ThrowAccessErrorException_IfEditReceiver()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            var newText = "asda";
            
            Assert.Throws<AccessErrorException>(()=>_chatService.EditMessage(message.Id, receiver.Id, newText));
        }
        
        [Test]
        public void EditMessage_ThrowNotFoundException_IfInvalidMessage()
        {
            var invalidId = "invalid id";
            var newText = "dsad";
            
            Assert.Throws<NotFoundException>(()=>_chatService.EditMessage(invalidId, invalidId, newText));
        }
        
        [Test]
        public void DeleteMessage_ThrowNotFoundException_IfInvalidMessage()
        {
            var invalidId = "invalid id";
            var newText = "dsad";
            
            Assert.Throws<NotFoundException>(()=>_chatService.DeleteMessage(invalidId, invalidId));
        }
        
        [Test]
        public void DeleteMessage_SuccessDeleted_IfValidData()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);

            _chatService.DeleteMessage(message.Id, sender.Id);
            
            Assert.False(
                _messageRepository.GetMessages(sender, receiver).Any());
        }
        
        [Test]
        public void DeleteMessage_ThrowAccessErrorException_IfDeleteReceiver()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            
            Assert.Throws<AccessErrorException>(()=>_chatService.DeleteMessage(message.Id, receiver.Id));
        }
        
        [Test]
        public void CanEditorAccessMessage_ReturnFalse_ForNotSender()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            var expected = false;

            var actual = _chatService.CanEditorAccessMessage(message.Id, receiver.Id);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CanEditorAccessMessage_ReturnTrue_ForSender()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var text = "message text";
            var message = _chatService.SendMessage(sender.Id, receiver.Id, text);
            var expected = true;

            var actual = _chatService.CanEditorAccessMessage(message.Id, sender.Id);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GetMessages_ReturnEmptyList_IfValidUsersWithoutMessages()
        {
            var sender = _users[0];
            var receiver = _users[1];

            var messages = _chatService.GetAllMessages(sender.Id, receiver.Id);

            Assert.False(messages.Any());
        }

        [Test]
        public void GetMessages_ReturnAllMessagesBetweenSenderAndReceiver_IfSenderHaveMessagesWithSomeReceivers()
        {
            var sender = _users[0];
            var receiver = _users[1];
            var otherReceiver = _users[2];

            _chatService.SendMessage(sender.Id, receiver.Id, "1 message");
            _chatService.SendMessage(receiver.Id, sender.Id, "2 message");
            _chatService.SendMessage(sender.Id, otherReceiver.Id, "3 message");
            _chatService.SendMessage(otherReceiver.Id, sender.Id, "4 message");

            var messages = _chatService.GetAllMessages(sender.Id, receiver.Id);

            Assert.AreEqual(2, messages.Count);
            Assert.True(messages.Any(m => m.Text == "2 message"));
            Assert.True(messages.Any(m => m.Text == "1 message"));
        }
        
    }
}