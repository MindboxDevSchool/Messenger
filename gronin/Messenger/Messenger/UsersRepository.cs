using System;
using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger
{
    public class UserRepository:IUsersRepository
    {
        public void CreateUser(IUser user)
        {
            _userDictionary[user.Id] = user;
        }

        public IUser GetUser(Guid memberId)
        {
            if(_userDictionary.ContainsKey(memberId))
                return _userDictionary[memberId];
            return null;
        }

        public void DeleteUser(Guid memberId)
        {
            _userDictionary.Remove(memberId);
        }

        private readonly Dictionary<Guid, IUser> _userDictionary = new Dictionary<Guid, IUser>();
    }
}