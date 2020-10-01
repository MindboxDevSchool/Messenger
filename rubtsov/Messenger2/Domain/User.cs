using System;
using System.Collections.Generic;
using Messenger2.Domain.Channel;

namespace Messenger2.Domain
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public readonly DateTime RegistrationDate;
        public Guid Id { get; set; }
        public Dictionary<Guid, LastSeenMessage> LastSeenMessageInParticipatingCommunities { get; set; }
        public User(Guid id) : this(id, string.Empty)
        {
        }

        public User(Guid id, string userName) 
        {
            Id = id;
            UserName = userName;
            RegistrationDate = DateTime.Now;
            //замечание про инициализацию в конструкторе читал. Оставил только здесь, чтобы во всех тестах 
            //не инициализировать каждый раз.
            LastSeenMessageInParticipatingCommunities = new Dictionary<Guid, LastSeenMessage>();
        }
    }
}