using System;

namespace Messenger.Domain
{
    public interface IChannelRepository
    {
        IChannel CreateChannel(IUser creator, string name);
        IChannel GetChannel(String channelId);
        void EditChannel(String channelId, string newName);
        void DeleteChannel(String channelId);
    }
}