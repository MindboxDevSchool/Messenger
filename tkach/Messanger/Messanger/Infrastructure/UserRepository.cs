using System;
using System.Collections.Generic;
using Messanger.Domain.UserModel;

namespace Messanger.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<Guid, IUser> _users;

        public Dictionary<Guid, IUser> Users
        {
            get
            {
                return new Dictionary<Guid, IUser>(this._users);
            }
        }

        public UserRepository(Dictionary<Guid, IUser> users)
        {
            this._users = new Dictionary<Guid, IUser>(users);
        }
        
        public IUser Load(Guid userId)
        {
            try
            {
                if (this._users.ContainsKey(userId))
                {
                    return this._users[userId];
                }
                else
                {
                    throw new Exception($"there is no such user with Guid {userId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void Save(IUser user)
        {
            try
            {
                if(user.Equals(null))
                    throw new Exception($"IUser entity is null");
                else
                {
                    this._users.Add(user.Id, user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}