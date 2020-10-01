using System.Linq;
using Crane.Domain;
using Crane.Infrastructure;

namespace Crane.Application
{
    public class UserService
    {
        private readonly IIdentityProvider _idProvider;
        private readonly IRepo<IUser> _userRepo;

        public UserService()
        {
            _idProvider = new SequentialIdentityProvider();
            _userRepo = new FileRepo<IUser>(".usr");
        }

        public IUser CreateUser(string name, string password)
        {
            int id = _idProvider.NextId;
            User user = new User(
                id,
                name,
                new SHA256PasswordHandler(password)
            );
            _userRepo.Add(user);
            return user;
        }

        public Maybe<IUser> GetUser(int id)
        {
            IUser user = _userRepo.Items.SingleOrDefault((u) => u.Id == id);
            return user == null
                ? new Maybe<IUser>.None()
                : (Maybe<IUser>) new Maybe<IUser>.Some(user);
        }
        
    }
}
