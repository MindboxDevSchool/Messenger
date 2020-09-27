using System;
using System.Collections.Generic;
using Application.Services.UserServices;
using Domain.User;
using MessengerTests.TestRepositories;
using NUnit.Framework;

namespace MessengerTests
{
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Is_Able_to_register_new_user_and_get_him_by_id()
        {
            var userRepository = new TestUserRepository(new Dictionary<Guid, IUser>());
            var userService = new UserService(userRepository);
            var expectedId = new Guid();
            var expectedUserName = new UserName("Stepa");
            var expectedPhoneNumber = new PhoneNumber("123");
            
            var actualId = userService.Register(expectedUserName, expectedPhoneNumber);
            var user = userService.GetUser(actualId);

            Assert.That(
                expectedId == actualId 
                && expectedUserName.Value == user.Name.Value
                && expectedPhoneNumber.Value == user.PhoneNumber.Value);
        }
    }
}