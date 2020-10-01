using System;
using System.Collections.Generic;

namespace Crane.Domain
{
    public class User : IUser
    {
        public IPasswordHandler PasswordHandler { get; }
        public string Name { get; }
        public int Id { get; }
        
        public static User Parse(string representation)
        {
            throw new NotImplementedException();
        }
        
        public static string Render(User user)
        {
            throw new NotImplementedException();
        }

        public User(int id, string name, IPasswordHandler passwordHandler)
        {
            PasswordHandler = passwordHandler;
            Name = name;
            Id = id;
        }
    }
}
