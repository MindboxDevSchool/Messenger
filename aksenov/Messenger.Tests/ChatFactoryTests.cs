using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Application;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChatFactoryTests
    {
        [Test]
        public void Create_NewChannel_ReturnChatWithCorrectCreatorRole()
        {
            // arrange
            var settings = new MessengerSettings(new Dictionary<RoleType, Dictionary<AccessType, bool>>(),
                new Dictionary<ChatType, int>()
                {
                    {ChatType.Channel, 10}
                });
            var userRepository = new UserRepository();
            var chatFactory = new ChatFactory(settings, userRepository);

            // act
            var chat = chatFactory.Create(ChatType.Channel, "Channel", Guid.NewGuid());

            // assert
            Assert.AreEqual(1, chat.Members.Count());
            Assert.AreEqual(RoleType.Author, chat.Members.First().Role);
        }
        
        class UserRepository: IUserRepository
        {
            public IUser GetBy(Guid userId)
            {
                var chatRole = new ChatRole(new Dictionary<AccessType, bool>()
                {
                    {AccessType.Write, false},
                    {AccessType.Read, true}
                });
            
                var availableChats = new Dictionary<Guid, ChatRole>()
                {
                    {Guid.NewGuid(), chatRole}
                };

                var user = new User(Guid.NewGuid(), "name", "8900", availableChats);

                return user;
            }

            public void Update(IUser user)
            {
                throw new NotImplementedException();
            }

            public void Update(IEnumerable<IUser> users)
            {
                throw new NotImplementedException();
            }

            public void Save(IUser user)
            {
                throw new NotImplementedException();
            }
        }
    }
}