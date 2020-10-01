using System;
using Domain.User;

namespace Application.Services.UserServices
{
    public interface IUserService
    {
        public Guid Register(UserName userName, PhoneNumber phoneNumber);
        public IUser GetUser(Guid id);
    }
}