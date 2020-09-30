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
        [Test]
        public void Can_register_new_user_and_get_him_by_id()
        {
            var expectedUserName = new UserName("Stepa");
            var expectedPhoneNumber = new PhoneNumber("4242");
            var userService = new UserService(new TestUserRepository(new Dictionary<Guid, IUser>()));
            
            var userId = userService.Register(expectedUserName, expectedPhoneNumber);
            var user = userService.GetUser(userId);

            Assert.AreEqual(expectedUserName.Text, user.Name.Text);
            Assert.AreEqual(expectedPhoneNumber.Text, user.PhoneNumber.Text);
        }
    }
}