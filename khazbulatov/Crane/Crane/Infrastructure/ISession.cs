using System;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public interface ISession : IIdentified
    {
        DateTime Expires { get; }
        IUser Owner { get; }
        string Token { get; }
    }
}
