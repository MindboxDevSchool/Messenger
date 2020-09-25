using System;
using Messenger.Domain;
using NUnit.Framework;

namespace MessengerUnitTests
{
    [TestFixture]
    public class ChannelChatTests
    {
        [Test]
        public void CreatorSendingMessageToChannel()
        {
            var channelCreator = new User("ivan", "1111");
            var channel = new  ChannelChat(channelCreator, "first channel chat");

            var messageId = channel.SendMessage(channelCreator, "Hello everyone!");
            var message = channel.GetMessage(messageId);

            Assert.AreEqual("Hello everyone!", message.MessageText);
        }
        [Test]
        public void CreatorDeletingMessageFromChannel()
        {
            var channelCreator = new User("ivan", "1111");
            var channel = new  ChannelChat(channelCreator, "first channel chat");
            
            var messageId = channel.SendMessage(channelCreator, "Hello everybody!");
            IMessage message = channel.GetMessage(messageId);
            channel.DeleteMessage(channelCreator, message);
            message = channel.GetMessage(messageId);
            
            Assert.AreEqual(null, message);
        }
    }
}