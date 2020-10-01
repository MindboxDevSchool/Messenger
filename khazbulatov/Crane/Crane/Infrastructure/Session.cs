using System;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public class Session : ISession
    {
        public int Id { get; }
        public DateTime Expires { get; }
        public IUser Owner { get; }
        public string Token { get; }
        
        public static Session Parse(string representation)
        {
            throw new NotImplementedException();
        }
        
        public static string Render(Session session)
        {
            throw new NotImplementedException();
        }

        public Session(int id, IUser owner, DateTime expires)
        {
            Id = id;
            Expires = expires;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Token = owner.PasswordHandler.GetToken(id);
        }
    }
}
