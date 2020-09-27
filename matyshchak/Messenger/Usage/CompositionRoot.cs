using Application.Services;
using Application.Services.UserServices;
using Infrastructure;
using Infrastructure.Repositories;

namespace Usage
{
    public class CompositionRoot
    {
        /*public static CompositionRoot Create()
        {
            var userRepository = new UserRepository();
            return new CompositionRoot()
            {
                UserService = new UserService(userRepository)
            };

        }
        
        public IUserService UserService { get; private set; }*/
    }
}