using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace Messenger.Domain
{
    public class User : IUser
    {

        public readonly DateTime RegistrationDate;
        public string Nickname { get; set; }
        
        public Guid Id { get; set; }
        public Dictionary<Guid, LastSeenMessage> LastSeenMessageInParticipatingCommunities { get; set; }

        public User(Guid id)
        {
            Id = id;
            RegistrationDate = DateTime.Now;
            LastSeenMessageInParticipatingCommunities = new Dictionary<Guid, LastSeenMessage>();
        }
        //TODO: только сам пользователь может менять свой ник
        

        public void ChangeNickname(Guid initiatorId, string newNickname)
        {
            if (initiatorId != Id)
            {
                throw new AuthenticationException("Only user can change his own nickname");
            }
            Nickname = newNickname;
        }
    }
}