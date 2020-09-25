using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class MessengerSettings
    {
        public Dictionary<RoleType, ChatRole> ChatRoles { get; }

        public Dictionary<ChatType, int> MaxMembers { get; }

        public MessengerSettings(Dictionary<RoleType, ChatRole> chatRoles, Dictionary<ChatType, int> maxMembers)
        {
            ChatRoles = chatRoles;
            MaxMembers = maxMembers;
        }

        public MessengerSettings(Dictionary<ChatType, int> maxMembers)
        {
            ChatRoles = CreateDefaultCredentials();
            MaxMembers = maxMembers;
        }

        public static MessengerSettings Default()
        {
            var maxMembers = new Dictionary<ChatType, int>()
            {
                {ChatType.Channel, 5000},
                {ChatType.Group, 500},
                {ChatType.Private, 2}
            };

            return new MessengerSettings(maxMembers);
        }

        private Dictionary<RoleType, ChatRole> CreateDefaultCredentials()
        {
            return new Dictionary<RoleType, ChatRole>()
            {
                {RoleType.Administrator, new ChatRole(
                    new Dictionary<AccessType, bool>()
                    {
                        {AccessType.Edit, true},
                        {AccessType.Read, true},
                        {AccessType.Write, true},
                        {AccessType.DeleteOwn, true},
                        {AccessType.DeleteSomeone, true}
                    })},
                {RoleType.Author, new ChatRole(
                    new Dictionary<AccessType, bool>()
                    {
                        {AccessType.Edit, true},
                        {AccessType.Read, true},
                        {AccessType.Write, true},
                        {AccessType.DeleteOwn, true},
                        {AccessType.DeleteSomeone, false}
                    })},
                {RoleType.ChannelParticipant, new ChatRole(
                    new Dictionary<AccessType, bool>()
                    {
                        {AccessType.Edit, false},
                        {AccessType.Read, true},
                        {AccessType.Write, false},
                        {AccessType.DeleteOwn, false},
                        {AccessType.DeleteSomeone, false}
                    })},
                {RoleType.GroupParticipant, new ChatRole(
                    new Dictionary<AccessType, bool>()
                    {
                        {AccessType.Edit, true},
                        {AccessType.Read, true},
                        {AccessType.Write, true},
                        {AccessType.DeleteOwn, true},
                        {AccessType.DeleteSomeone, false}
                    })},
                {RoleType.PrivateParticipant, new ChatRole(
                    new Dictionary<AccessType, bool>()
                    {
                        {AccessType.Edit, true},
                        {AccessType.Read, true},
                        {AccessType.Write, true},
                        {AccessType.DeleteOwn, true},
                        {AccessType.DeleteSomeone, false}
                    })},
            };
        }
    }
}