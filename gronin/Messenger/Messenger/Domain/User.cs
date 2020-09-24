using System;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class User : IUser
    {
        public User(UserData data)
        {
            Id = Guid.NewGuid();
            Data = data;
        }
        public Guid Id { get; }

        public UserData Data { get; set; }


    }
}