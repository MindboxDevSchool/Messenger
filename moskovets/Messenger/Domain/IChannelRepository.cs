using System;

namespace Messenger.Domain
{
    public interface IChannelRepository
    {
        IChannel CreateChannel(IUser creator, string name);
        IChannel GetChannel(String channelId);
        void EditChannel(String channelId, string newName);
        void AddMember(String channelId, IUser member);
        void RemoveMember(String channelId, IUser member);
        void DeleteChannel(String channelId);
        bool HasMember(String channelId, IUser member);
    }
}