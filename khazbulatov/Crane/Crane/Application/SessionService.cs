using System;
using System.Linq;
using Crane.Domain;
using Crane.Infrastructure;

namespace Crane.Application
{
    public class SessionService
    {
        private readonly IIdentityProvider _idProvider;
        private readonly IRepo<ISession> _sessionRepo;

        public SessionService()
        {
            _idProvider = new SequentialIdentityProvider();
            _sessionRepo = new FileRepo<ISession>(".ssn");
        }

        public Maybe<ISession> CreateSession(IUser user, string password)
        {
            if (!user.PasswordHandler.VerifyPassword(password)) return new Maybe<ISession>.None();
            
            int id = _idProvider.NextId;
            Session session = new Session(
                id,
                user,
                DateTime.Now
            );
            _sessionRepo.Add(session);
            return new Maybe<ISession>.Some(session);
        }

        public Maybe<ISession> GetSession(string token)
        {
            ISession session = _sessionRepo.Items.SingleOrDefault((s) => s.Token == token);
            return session == null
                ? new Maybe<ISession>.None()
                : (Maybe<ISession>) new Maybe<ISession>.Some(session);
        }
    }
}
