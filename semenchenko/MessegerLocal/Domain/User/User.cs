using System;

namespace Messeger.Domain
{
    public class User : IUser
    {
        public Guid Id { get; }
        public Credentials Credentials { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public ProfilePicture Picture { get; }
    }
}