﻿using System.Collections.Generic;
using Messenger.Domain.Roles;

namespace Messenger.Domain.Chats
{
    public interface IChannel
    {
        OperationStatus AddMessage(ICreator creatorChannel, string textMessage);
        OperationStatus DeleteMessage(ICreator channelCreator, int messageId);     
        OperationStatus EditMessage(ICreator channelCreator, int messageId, string textForReplace);
    }
}