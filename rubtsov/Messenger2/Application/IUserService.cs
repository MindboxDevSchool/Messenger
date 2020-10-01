using System;
using Messenger2.Domain;

namespace Messenger2.Application
{
    public interface IUserService
    {
        public IUser RegisterUser(string userName, Guid id);
        public IUser GetUser(Guid id);
        public IUser GetUser(string userName);
    }
}