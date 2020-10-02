using System;
using System.Collections.Generic;

namespace Messeger.Domain
{
    public interface IUser
    {
        Guid Id { get; }
        Credentials Credentials { get; }
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
        ProfilePicture Picture { get; }
    }
}