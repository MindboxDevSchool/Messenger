using System;
using System.Collections.Generic;
using Domain.Chats;

namespace Domain.User
{
    public class User : IUser
    {
        private User(Guid id, UserName name, PhoneNumber phoneNumber, IEnumerable<IChat> chats)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Chats = chats;
        }

        public Guid Id { get; }
        public UserName Name { get; }
        public PhoneNumber PhoneNumber { get; }
        public IEnumerable<IChat> Chats { get; }

        public static User Create(Guid id, UserName name, PhoneNumber phoneNumber)
        {
            return new User(id, name, phoneNumber, new List<IChat>());
        }

    }
}