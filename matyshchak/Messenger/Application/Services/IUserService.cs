using System;
using System.Collections.Generic;
using Domain.Chat;
using Domain.User;

namespace Application.Services
{
    public interface IUserService
    {
        public Guid Register(UserName userName, PhoneNumber phoneNumber);
        public IUser GetUser(Guid id);
    }
}