using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;
using NUnit.Framework;

namespace Messenger.Tests
{
    public class ChatTests
    {
        private static Guid chatId = Guid.NewGuid();
        private static Guid creatorId = Guid.NewGuid();
        private static Guid userId1 = Guid.NewGuid();
        private static Guid message1 = Guid.NewGuid();
        private static Guid message2 = Guid.NewGuid();

        private Chat chat;

        [SetUp]
        public void SetUp()
        {
            chat = new Chat(
                chatId,
                "MainChat",
                ChatType.Channel,
                new List<Message>()
                {
                    new Message(message1, creatorId, "Message1", DateTime.Now),
                    new Message(message2, creatorId, "Message2", DateTime.Now)
                },
                new List<ChatMember>()
                {
                    new ChatMember(new User(creatorId, "User1", "Phone1",
                        new Dictionary<Guid, ChatRole>()), RoleType.Author),
                    new ChatMember(new User(userId1, "User2", "Phone2",
                        new Dictionary<Guid, ChatRole>()), RoleType.ChannelParticipant)
                },
                new List<RoleType>() {RoleType.Author, RoleType.ChannelParticipant},
                100, RoleType.ChannelParticipant);
        }

        [Test]
        public void TryUpdateMessage_SuccessfulUpdate_CorrectNewMessageContent()
        {
            // arrange
            var updatedMessage = new Message(message1, creatorId, "new content", DateTime.Now);
            
            // act
            chat.TryUpdateMessage(updatedMessage);
            var newContent = chat.Messages.First(m => m.Id == message1).Content;

            // assert
            Assert.AreEqual("new content", newContent);
        }
        
        [Test]
        public void TryDeleteMessage_SuccessfulDeleteMessageFromChat()
        {
            // arrange

            // act
            chat.TryDeleteMessage(message1);
            var deletedMessage = chat.Messages.FirstOrDefault(m => m.Id == message1);

            // assert
            Assert.IsNull(deletedMessage);
        }
        
        [Test]
        public void TryChangeMemberRole_SuccessfulChangeToAvailableRole()
        {
            // arrange
            var newRole = RoleType.Author;

            // act
            chat.TryChangeMemberRole(userId1, newRole);
            var changedRole = chat.Members.First(m => m.User.Id == userId1).Role;

            // assert
            Assert.AreEqual(RoleType.Author, changedRole);
        }
        
        [Test]
        public void GetMemberBy_Id_ReturnCorrectMember()
        {
            // arrange

            // act
            var member = chat.GetMemberBy(creatorId);

            // assert
            Assert.AreEqual("User1", member.User.Name);
        }
    }
}