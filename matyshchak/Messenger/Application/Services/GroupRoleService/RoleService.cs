using System;
using Domain.Chats;
using Domain.Repositories;
using Domain.User;

namespace Application.Services.GroupRoleService
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IContext _context;

        public RoleService(IUserRepository userRepository, IChatRepository chatRepository, IContext context)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
            _context = context;
        }

        public void MakeUserGroupAdmin(Guid userId, Guid chatId)
        {
            var currentUser = _userRepository.GetUser(_context.GetCurrentUserId());
            var chat = _chatRepository.GetChat(chatId);

            if (!(chat is IGroup group))
                throw new Exception();
            
            if (!currentUser.IsGroupAdmin(group))
                throw new Exception();

            group.PromoteToAdmin(currentUser);
        }

        public void MakeUserRegularGroupMember(Guid userId, Guid chatId)
        {
            throw new NotImplementedException();
        }
    }
}