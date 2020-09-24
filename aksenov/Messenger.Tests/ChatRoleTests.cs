using System.Collections.Generic;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChatRoleTests
    {
        [Test]
        public void GetAccessFor_AvailableActionType_ReturnTrue()
        {
            // arrange
            var chatRole = new ChatRole(new Dictionary<AccessType, bool>()
            {
                {AccessType.Write, false},
                {AccessType.Read, true}
            });
            
            // act
            var haveAccess = chatRole.GetAccessFor(AccessType.Read);

            // assert
            Assert.IsTrue(haveAccess);
        }
    }
}