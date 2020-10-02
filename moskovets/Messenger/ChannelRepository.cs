using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class ChannelRepository : IChannelRepository
    {
        private List<IChannel> _channels;

        public ChannelRepository()
        {
            _channels = new List<IChannel>();
        }

        public IChannel CreateChannel(IUser creator, string name)
        {
            var id = Guid.NewGuid().ToString("N");
            var channel = new Channel(id, name, creator);
            _channels.Add(channel);
            return channel;
        }

        public IChannel GetChannel(string channelId)
        {
            var channel = _channels.FirstOrDefault(m => m.Id == channelId);
            if (channel == null)
                throw new NotFoundException();
            return channel;
        }

        public void EditChannel(string channelId, string newName)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteChannel(string channelId)
        {
            _channels.RemoveAll(c => c.Id == channelId);
        }
    }
}