using System;
using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class UserTests
    {
        [Test]
        public void HaveAccessTo_AvailableActions()
        {
            // arrange
            var chatId = Guid.NewGuid();

            var chatRole = new ChatRole(new Dictionary<AccessType, bool>()
            {
                {AccessType.Write, false},
                {AccessType.Read, true}
            });
            
            var availableChats = new Dictionary<Guid, ChatRole>()
            {
                {chatId, chatRole}
            };

            var user = new User(Guid.NewGuid(), "name", "8900", availableChats);

            // act
            var doesHaveAccess = user.HaveAccessTo(chatId, AccessType.Write);

            // assert
            Assert.IsFalse(doesHaveAccess);
        }
    }
}