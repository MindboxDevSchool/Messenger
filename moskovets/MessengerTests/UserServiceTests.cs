using Messenger;
using Messenger.Application;
using NUnit.Framework;

namespace MessengerTests
{
    public class UserServiceTests
    {
        private UserService _userService;
        private UserRepository _userRepository;
        
        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
        }

        [Test]
        public void CreateUser_SuccessSaved_IfValidUser()
        {
            var login = "nana";

            var user = _userService.CreateUser(login);

            Assert.AreEqual(login, user.Login);
            var savedUser = _userRepository.GetUser(user.Id);
            Assert.True(savedUser.Equals(user));
        }
        
        [Test]
        public void EditUser_SuccessEdited_IfValidUser()
        {
            var login = "nana";
            var user = _userService.CreateUser(login);
            var newLogin = "new_nana";
            
            _userRepository.EditUser(user.Id, newLogin);
            var editedUser = _userRepository.GetUser(user.Id);
            
            Assert.AreEqual(newLogin, editedUser.Login);
        }

        [Test]
        public void EditUser_ThrowNotFoundException_IfInvalidUser()
        {
            var id = "ivalid id";
            var newLogin = "new_nana";
            
            Assert.Throws<NotFoundException>(()=>_userService.EditLogin(id, newLogin));
        }
    }
}