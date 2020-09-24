using System;
using System.Collections;
using System.Collections.Generic;
using Messenger.Application;

namespace Messenger.Domain
{
    public class ChatFactory : IChatFactory
    {
        public ChatFactory(MessengerSettings messengerSettings, IUserRepository userRepository)
        {
            _messengerSettings = messengerSettings;
            _userRepository = userRepository;
        }
        
        public IChat Create(ChatType chatType, string name, Guid creatorId)
        {
            switch (chatType)
            {
                case ChatType.Channel: return getNewChannelChat(name, creatorId);
                case ChatType.Group: return getNewGroupChat(name, creatorId);
                case ChatType.Private: return getNewPrivateChat(name, creatorId);
                default: throw new ChatTypeNotRecognizedException(chatType);
            }
        }

        private Chat getNewChannelChat(string name, Guid creatorId)
        {
            var messages = new List<Message>();
            
            var creator = _userRepository.GetBy(creatorId);
            var members = new List<ChatMember>()
            {
                new ChatMember(creator, RoleType.Author)
            };
            
            var defaultRole = RoleType.ChannelParticipant;
                    
            var availableRoles = new List<RoleType>()
            {
                RoleType.Author,
                RoleType.ChannelParticipant
            };

            var maxMembers = _messengerSettings.MaxMembers[ChatType.Channel];
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Channel, messages, 
                                members, availableRoles,maxMembers, defaultRole);
        }
        
        private Chat getNewGroupChat(string name, Guid creatorId)
        {
            var messages = new List<Message>();
            
            var creator = _userRepository.GetBy(creatorId);
            var members = new List<ChatMember>()
            {
                new ChatMember(creator, RoleType.Administrator)
            };
            
            var defaultRole = RoleType.GroupParticipant;
                    
            var availableRoles = new List<RoleType>()
            {
                RoleType.Administrator,
                RoleType.GroupParticipant
            };

            var maxMembers = _messengerSettings.MaxMembers[ChatType.Group];
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Group, messages, 
                members, availableRoles,maxMembers, defaultRole);
        }
        
        private Chat getNewPrivateChat(string name, Guid creatorId)
        {
            var messages = new List<Message>();
            
            var creator = _userRepository.GetBy(creatorId);
            var members = new List<ChatMember>()
            {
                new ChatMember(creator, RoleType.PrivateParticipant)
            };
            
            var defaultRole = RoleType.PrivateParticipant;
                    
            var availableRoles = new List<RoleType>()
            {
                RoleType.PrivateParticipant
            };

            var maxMembers = _messengerSettings.MaxMembers[ChatType.Private];
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Private, messages, 
                members, availableRoles,maxMembers, defaultRole);
        }
        
        private MessengerSettings _messengerSettings;
        private IUserRepository _userRepository;
    }
}