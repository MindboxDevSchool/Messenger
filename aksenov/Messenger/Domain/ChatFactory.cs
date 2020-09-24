using System;
using System.Collections;
using System.Collections.Generic;
using Messenger.Application;
using Messenger.Exceptions;

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
            return chatType switch
            {
                ChatType.Channel => GetNewChannelChat(name, creatorId),
                ChatType.Group => GetNewGroupChat(name, creatorId),
                ChatType.Private => GetNewPrivateChat(name, creatorId),
                _ => throw new ChatTypeNotRecognizedException(chatType)
            };
        }

        private Chat GetNewChannelChat(string name, Guid creatorId)
        {
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
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Channel, new List<Message>(), 
                                members, availableRoles,maxMembers, defaultRole);
        }
        
        private Chat GetNewGroupChat(string name, Guid creatorId)
        {
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
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Group, new List<Message>(), 
                members, availableRoles,maxMembers, defaultRole);
        }
        
        private Chat GetNewPrivateChat(string name, Guid creatorId)
        {
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
                    
            return new Chat(Guid.NewGuid(), name, ChatType.Private, new List<Message>(), 
                members, availableRoles,maxMembers, defaultRole);
        }
        
        private readonly MessengerSettings _messengerSettings;
        private readonly IUserRepository _userRepository;
    }
}