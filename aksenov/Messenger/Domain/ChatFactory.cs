using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class ChatFactory : IChatFactory
    {
        public ChatFactory(MessengerSettings messengerSettings)
        {
            _messengerSettings = messengerSettings;
        }
        
        public IChat Create(ChatType chatType, string name)
        {
            switch (chatType)
            {
                case ChatType.Channel: return getNewChannelChat(name);
                case ChatType.Group: return getNewGroupChat(name);
                case ChatType.Private: return getNewPrivateChat(name);
                default: throw new ChatTypeNotRecognizedException(chatType);
            }
        }

        private Chat getNewChannelChat(string name)
        {
            var messages = new List<Message>();
            var members = new List<ChatMember>();
            
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
        
        private Chat getNewGroupChat(string name)
        {
            var messages = new List<Message>();
            var members = new List<ChatMember>();
            
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
        
        private Chat getNewPrivateChat(string name)
        {
            var messages = new List<Message>();
            var members = new List<ChatMember>();
            
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
    }
}