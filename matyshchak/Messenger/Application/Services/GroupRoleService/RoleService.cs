using System;
using Domain.Chats;
using Domain.Repository;
using Domain.User;
using Domain.UserPermissions;
using Domain.UserPermissions.Exceptions;

namespace Application.Services.GroupRoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<IGroup> _groupRepository;
        private readonly IRepository<IUser> _userRepository;
        private readonly IContext _context;

        public RoleService(IRepository<IGroup> groupRepository, IRepository<IUser> userRepository, IContext context)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _context = context;
        }
        
        public void PromoteToAdmin(Guid userToPromoteId, Guid groupId)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var userToPromote = _userRepository.Find(userToPromoteId);
            var group = _groupRepository.Find(groupId);
            
            if (!currentUser.IsMemberOf(group) || !userToPromote.IsMemberOf(group))
                throw new NotMemberOfChatException();
            
            if (!currentUser.IsOwnerOf(group))
                throw new NoPermissionToChangeAdminsException();

            group.AddAdmin(userToPromote);
        }

        public void DemoteFromAdmin(Guid userToDemoteId, Guid groupId)
        {
            var currentUser = _userRepository.Find(_context.CurrentUserId);
            var userToDemote = _userRepository.Find(userToDemoteId);
            var group = _groupRepository.Find(groupId);
            
            if (!currentUser.IsMemberOf(group) || !userToDemote.IsMemberOf(group))
                throw new NotMemberOfChatException();
            
            if (!currentUser.IsOwnerOf(group))
                throw new NoPermissionToChangeAdminsException();

            group.RemoveAdmin(userToDemote);
        }
    }
}