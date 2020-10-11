using System;
using System.Collections.Generic;
using System.Xml.Schema;
using Messenger.Domain;

namespace Messenger.Application
{
    public interface IChannelService
    {
        IChannel CreateChannel(String creatorId, string name);
        void AddMember(String memberId, String channelId);
        void RemoveMember(String memberId, String channelId);
        IReadOnlyCollection<IUser> GetMembers(String channelId);
    }
}