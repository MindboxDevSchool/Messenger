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

        public SessionService() : this(
            new SequentialIdentityProvider(),
            new FileRepo<ISession>(".ssn")
        ) { }

        public SessionService(IIdentityProvider idProvider, IRepo<ISession> sessionRepo)
        {
            _idProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            _sessionRepo = sessionRepo ?? throw new ArgumentNullException(nameof(sessionRepo));
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
