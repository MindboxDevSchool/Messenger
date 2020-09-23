using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain
{
    public class Chat : IChat
    {
        public Guid Id { get; }
        public ChatType Type { get; }
        public string Name { get; }
        public int MaxMembers { get; }
        public RoleType DefaultMemberRole { get; }

        public IEnumerable<Message> Messages => _messages;

        public IEnumerable<ChatMember> Members => _members;
        
        public IEnumerable<RoleType> AvailableRoles => _availableRoles;

        public void PostMessage(Message message)
        {
            _messages.Add(message);
        }

        public void TryUpdateMessage(Message updatedMessage)
        {
            var oldMessage = _messages.FirstOrDefault(message => message.Id == updatedMessage.Id);
            
            if (oldMessage == null)
                throw new MessageNotFoundException(updatedMessage.Id);
            
            oldMessage.ChangeContent(updatedMessage.Content);
        }
        
        public void TryDeleteMessage(Guid messageId)
        {
            var deletedMessage = _messages.FirstOrDefault(message => message.Id == messageId);
            
            if (deletedMessage == null)
                throw new MessageNotFoundException(messageId);
            
            _messages.Remove(deletedMessage);
        }

        public void TryChangeMemberRole(Guid userId, RoleType newRole)
        {
            if (!_availableRoles.Contains(newRole))
            {
                throw new InvalidRoleException(newRole);
            }

            var member = _members.FirstOrDefault(m => m.User.Id == userId);

            if (member == null)
            {
                throw new ChatMemberNotFoundException(userId);
            }

            if (newRole != member.Role)
            {
                member.ChangeRole(newRole);
            }
        }

        public void AddMember(IUser user)
        {
            if (_members.Count == MaxMembers)
            {
                throw new MemberLimitExceededException(MaxMembers);
            }
            
            var chatMember = new ChatMember(user, DefaultMemberRole);
            _members.Add(chatMember);
        }

        public Chat(Guid id, string name, ChatType type, 
                        IEnumerable<Message> messages, IEnumerable<ChatMember> members,
                        IEnumerable<RoleType> availableRoles, int maxMembers, RoleType defaultMemberRole)
        {
            Id = id;
            Type = type;
            MaxMembers = maxMembers;
            DefaultMemberRole = defaultMemberRole;
            _messages = new List<Message>(messages);
            _members = new List<ChatMember>(members);
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _availableRoles = new List<RoleType>(availableRoles);
        }

        protected readonly List<Message> _messages;

        protected readonly List<ChatMember> _members;

        protected readonly List<RoleType> _availableRoles;
    }
}