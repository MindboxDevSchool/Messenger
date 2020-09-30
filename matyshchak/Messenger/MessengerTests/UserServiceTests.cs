using System;
using System.Collections.Generic;
using Application.Services.UserServices;
using Domain.Repository;
using Domain.User;
using MessengerTests.TestRepositories;
using Moq;
using NUnit.Framework;

namespace MessengerTests
{
    public class UserServiceTests
    {
        private IUserService _userService;
        private Mock<IRepository<IUser>> _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new Mock<IRepository<IUser>>(MockBehavior.Strict);
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public void Can_register_new_user_and_get_him_by_id()
        {
            var userRepository = new TestUserRepository(new Dictionary<Guid, IUser>());
            var userService = new UserService(userRepository);
            
            var expectedUserName = new UserName("Stepa");
            var expectedPhoneNumber = new PhoneNumber("4242");
            
            var userId = userService.Register(expectedUserName, expectedPhoneNumber);
            var user = userService.GetUser(userId);

            Assert.That(
                expectedUserName.Text == user.Name.Text
                && expectedPhoneNumber.Text == user.PhoneNumber.Text);
        }
    }
}