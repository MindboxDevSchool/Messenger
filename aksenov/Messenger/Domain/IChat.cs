﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public interface IChat
    {
        Guid Id { get; }
        ChatType Type { get; }
        string Name { get; }
        int MaxMembers { get; }
        RoleType DefaultMemberRole { get; }
        IEnumerable<Message> Messages { get; }
        IEnumerable<ChatMember> Members { get; }
        IEnumerable<RoleType> AvailableRoles { get; }
        void PostMessage(Message message);
        void TryUpdateMessage(Message updatedMessage);
        void TryDeleteMessage(Guid messageId);
        void AddMember(IUser user);
        void TryChangeMemberRole(Guid userId, RoleType newRole);
    }
}