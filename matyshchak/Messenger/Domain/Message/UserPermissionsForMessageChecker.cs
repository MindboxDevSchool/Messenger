using Domain.Chat;
using Domain.Repositories;
using Domain.User;

namespace Domain
{
    public class UserPermissionsForMessageChecker : IUserPermissionsForMessageChecker
    {
        private IUserRepository _userRepository;
        private IChatRepository _chatRepository;

        public UserPermissionsForMessageChecker(IUserRepository userRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }


        public bool HasPermissionsToDelete(IUser user, IChat chat)
        {
            return true;
        }

        public bool HasPermissionsToPost(IUser user, IChat chat)
        {
            throw new System.NotImplementedException();
        }

        public bool HasPermissionsToEdit(IUser user, IChat chat)
        {
            throw new System.NotImplementedException();
        }
    }
}