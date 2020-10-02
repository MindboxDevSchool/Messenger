using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger.Application
{
    public class GroupService : IGroupService, IChatService
    {
        private IUserRepository _userRepository;
        private IMessageRepository _messageRepository;
        private IGroupRepository _groupRepository;

        public GroupService(IUserRepository userRepository, IMessageRepository messageRepository,
            IGroupRepository groupRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public IGroup CreateGroup(string creatorId, string name)
        {
            var creator = _userRepository.GetUser(creatorId);
            return _groupRepository.CreateGroup(creator, name);
        }

        public void AddMember(string memberId, string groupId)
        {
            var member = _userRepository.GetUser(memberId);
            var group = _groupRepository.GetGroup(groupId);
            if (group.CreatorId != member.Id)
                group.AddMember(member);
        }

        public void RemoveMember(string memberId, string groupId)
        {
            var member = _userRepository.GetUser(memberId);
            var group = _groupRepository.GetGroup(groupId);
            if (!group.HasMember(member))
                throw new MemberNotFoundException();
            if (group.CreatorId == member.Id)
                throw new RemovingCreatorException();
            group.RemoveMember(member);
        }

        public void ChangeRole(string memberId, Role role, string groupId)
        {
            var member = _userRepository.GetUser(memberId);
            var group = _groupRepository.GetGroup(groupId);
            if (!group.HasMember(member))
                throw new MemberNotFoundException();
            if (group.CreatorId == member.Id)
                throw new InvalidAccessException(); 
            group.SetRole(member, role);
        }

        public IReadOnlyCollection<IUser> GetMembers(string groupId)
        {
            var group = _groupRepository.GetGroup(groupId);
            var users = group.GetMembers();
            return users.Select(uId => _userRepository.GetUser(uId)).ToList();
        }

        // ChatService
        
        public IMessage SendMessage(string senderId, string receiverId, string text)
        {
            var sender = _userRepository.GetUser(senderId);
            var group = _groupRepository.GetGroup(receiverId);
            if (!group.HasMember(sender))
                throw new MemberNotFoundException();
            return _messageRepository.CreateMessage(text, sender, group);
        }

        public void EditMessage(string messageId, string editorId, string newText)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new InvalidAccessException();

            if (String.IsNullOrEmpty(newText))
                throw new InvalidTextException();
            _messageRepository.EditMessage(messageId, newText);
        }

        public void DeleteMessage(string messageId, string editorId)
        {
            if (!CanEditorAccessMessage(messageId, editorId))
                throw new InvalidAccessException();
            _messageRepository.DeleteMessage(messageId);
        }

        public IReadOnlyCollection<IMessage> GetAllMessages(string senderId, string receiverId)
        {
            var member = _userRepository.GetUser(senderId);
            var group = _groupRepository.GetGroup(receiverId);
            if (!group.HasMember(member))
                throw new MemberNotFoundException();

            return _messageRepository.GetMessages(group);
        }

        public bool CanEditorAccessMessage(string messageId, string editorId)
        {
            var message = _messageRepository.GetMessage(messageId);
            var group = _groupRepository.GetGroup(message.Receiver.Id);
            var editor = _userRepository.GetUser(editorId);
            
            if (!group.HasMember(editor))
                throw new MemberNotFoundException();

            return message.Sender.Id == editorId || 
                   group.GetRole(editor) == Role.Admin;
        }
    }
}